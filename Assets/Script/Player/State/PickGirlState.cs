using UnityEngine;

public class PickGirlState : GirlState
{
    [SerializeField] private TextUI _girlNameText;
    [SerializeField] private GameObject particleFinishObj;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private ParticleSystem particleFinish;
    [SerializeField] private InterfaceSwitcher _interface;
    [SerializeField] private GirlCollectionMenu _girlCollectionMenu;

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
        _girl = girl.Data;
        _girlNameText.SetText(_girl.GirlName);
        _interface.ShowMenu(MenuType.PickMenu);
        particleFinishObj.gameObject.SetActive(true);
        particleFinish.Play();
        audioManager.PlayPicupVois();
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
