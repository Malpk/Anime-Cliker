using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _playerMoney;
    [Header("Reference")]
    [SerializeField] private TextUI _clickText;
    [SerializeField] private TextUI _moneyText;

    public int Money
    {
        get
        {
            return _playerMoney;
        }
        private set
        {
            _playerMoney = value;
            _moneyText?.SetText(_playerMoney, 8);
        }
    }

    private void OnValidate()
    {
        Money = _playerMoney;
    }

    public void TakeMoney(int money)
    {
        Money += money;
    }

    public bool GiveMoney(int money)
    {
        if (money <= Money)
        {
            Money -= money;
            return true;
        }
        return false;
    }

    public void TakeClickMoney(int money)
    {
        _clickText?.SetText(money);
        TakeMoney(money);
    }
}
