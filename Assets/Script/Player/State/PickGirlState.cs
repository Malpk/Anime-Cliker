using UnityEngine;

public class PickGirlState : GirlState
{
    [SerializeField] private InterfaceSwitcher _interface;

    public override void Enter(Girl girl)
    {
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
