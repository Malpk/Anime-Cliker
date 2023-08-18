using UnityEngine;

public class PickGirlState : GirlState
{
    [SerializeField] private TextUI _girlNameText;
    [SerializeField] private InterfaceSwitcher _interface;
    [SerializeField] private ParticleSystem particleFinish;
    [SerializeField] private GameObject particleFinishObj;
    private void Start()
    {
        particleFinishObj.gameObject.SetActive(true);  
        particleFinish.Stop();
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
        _interface.ShowMenu(MenuType.HUD);
        particleFinishObj.gameObject.SetActive(false);
    }

}
