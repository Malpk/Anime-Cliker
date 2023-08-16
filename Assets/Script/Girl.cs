using UnityEngine;

public class Girl : MonoBehaviour
{ 
    [SerializeField] private int _money;
    [Header("Reference")]
    [SerializeField] private TextUI _clickText;
    [SerializeField] private TextUI _moneyText;
    [SerializeField] private Animator _animator;

    private int _click = 1;
    private int _boost = 1;

    protected int curretClick => _boost * _click;
    private int _curretMoney 
    {
        get 
        {
            return _money;
        }
        set
        {
            _money = value;
            _moneyText?.SetText(_money, 8);
        } 
    }
     
    private void OnValidate()
    {
        _curretMoney = _money;
        _clickText?.SetText(curretClick);
    }

    private void OnMouseUp()
    {
        _curretMoney += curretClick;
        _animator.SetTrigger("up"); 
    }

    public void AddClick()
    {
        _click++;
        _clickText.SetText(curretClick);
    }

    public void SetBoost(int boost)
    {
        _boost = boost > 1 ? boost : 1;
        _clickText.SetText(curretClick);
    }

    public bool GiveMoney(int money)
    {
        if (_curretMoney - money >= 0)
        {
            _curretMoney -= money;
            return true;
        }
        else
        {
            return false;
        }
    }

}
