using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _click = 1;
    [Header("Reference")]
    [SerializeField] private Girl _girl;
    [SerializeField] private TextUI _clickText;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private AudioManager _girlSound;

    private int _boost = 1;
    private bool _isBlock;

    public int CurretClick => _boost * _click;

    private void OnMouseUp()
    {
        if (!_isBlock)
        {
            _animator.SetTrigger("up");
            _girl.UpdateGirl(CurretClick);
            _wallet.TakeClickMoney(CurretClick);
            _girlSound.PlayVois();
        }
    }

    public void AddClick()
    {
        _click++;
        _clickText.SetText(CurretClick);
    }

    public void SetBoost(int boost)
    {
        _boost = boost > 1 ? boost : 1;
        _clickText.SetText(CurretClick);
    }

    public void SetBolock(bool block)
    {
        _isBlock = block;
    }
}
