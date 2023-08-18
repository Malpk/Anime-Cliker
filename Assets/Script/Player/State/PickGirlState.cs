using UnityEngine;

public class PickGirlState : GirlState
{
    [SerializeField] private TextUI _girlNameText;
    [SerializeField] private InterfaceSwitcher _interface;
    [SerializeField] private GirlCollectionMenu _girlMenu;

    private GirlData _girl;

    public override void Enter(Girl girl)
    {
        _girl = girl.Data;
        _girlNameText.SetText(_girl.GirlName);
        _interface.ShowMenu(MenuType.PickMenu);
    }

    public override bool UpdateState(int click)
    {
        return true;
    }

    public override void Exit()
    {
        _girlMenu.Open(_girl);
        _interface.ShowMenu(MenuType.HUD);
    }

}
