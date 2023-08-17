using UnityEngine;

public class PickGirlState : GirlState
{
    [SerializeField] private TextUI _girlNameText;
    [SerializeField] private InterfaceSwitcher _interface;

    public override void Enter(Girl girl)
    {
        _girlNameText.SetText(girl.Data.GirlName);
        _interface.ShowMenu(MenuType.PickMenu);
    }

    public override bool UpdateState(int click)
    {
        return true;
    }

    public override void Exit()
    {
        _interface.ShowMenu(MenuType.HUD);
    }

}
