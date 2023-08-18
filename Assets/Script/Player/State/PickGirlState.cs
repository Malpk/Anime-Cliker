using UnityEngine;

public class PickGirlState : GirlState
{
    [SerializeField] private TextUI _girlNameText;
    [SerializeField] private GirlCollectionMenu _girlCollectionMenu;
    [SerializeField] private InterfaceSwitcher _interface;
    [SerializeField] private ParticleSystem particleFinish;
    [SerializeField] private GameObject particleFinishObj;

    private GirlData _girl;

    public override GirlStateType TypeState => GirlStateType.PickState;

    private void Start()
    {
        particleFinishObj.gameObject.SetActive(true);  
        particleFinish.Stop();
    }

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
        _girlNameText.SetText(girl.Data.GirlName);
        _interface.ShowMenu(MenuType.PickMenu);
        particleFinishObj.gameObject.SetActive(true);
        particleFinish.Play();
    }

    public override bool UpdateState(int click)
    {
        return true;
    }

    public override void Exit()
    {
        if(_girl)
            _girlCollectionMenu.Open(_girl);
        _interface.ShowMenu(MenuType.HUD);
        particleFinishObj.gameObject.SetActive(false);
    }

}
