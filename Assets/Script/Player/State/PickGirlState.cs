using UnityEngine;

public class PickGirlState : GirlState
{
    [SerializeField] private TextUI _girlNameText;
    [SerializeField] private InterfaceSwitcher _interface;
    [SerializeField] private GirlCollectionMenu _girlMenu;

    private GirlData _girl;

    public override GirlStateType TypeState => GirlStateType.PickState;

    public override StateData Save()
    {
        var data = new StateData();
        data.State = TypeState;
        return data;
    }

    public override void Load(StateData json)
    {
    }

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
        if(_girl)
            _girlMenu.Open(_girl);
        _interface.ShowMenu(MenuType.HUD);
    }


}
