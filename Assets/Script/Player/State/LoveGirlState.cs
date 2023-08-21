using UnityEngine;

public class LoveGirlState : GirlState
{
    [Min(10)]
    [SerializeField] private int _requredLove;
    [Min(1)]
    [SerializeField] private int _delay = 1;
    [SerializeField] private string _endWords = "Забирай меня скорей!!!";
    [Header("Reference")]
    [SerializeField] private TextUI _name;
    [SerializeField] private FieldUI _loveField;
    [SerializeField] private GameObject particleLoveObj;
    [SerializeField] private AudioManager _girlSound;
    [SerializeField] private DialogWindow _dialogWindow;
    [SerializeField] private ParticleSystem particleLove;
   
    private int _delayProgress;
    private float _progress;
    private GirlData _girl;

    public override GirlStateType TypeState => GirlStateType.LoveState;

    public void Start()
    {
        particleLoveObj.gameObject.SetActive(true);
        particleLove.Stop();
    }
    private void Reset()
    {
        _delay = 3;
        _requredLove = 20;
    }


    public override StateData Save()
    {
        var data = new StateData();
        data.State = TypeState;
        data.Progress = _progress;
        return data;
    }

    public override void Load(StateData data)
    {
        _progress = data.Progress;
        _loveField.UpdateValue(_progress / _requredLove);
    }

    public override void Enter(Girl girl)
    {
        _progress = 0;
        _delayProgress = _delay;
        _girl = girl.Data;
        _name.SetText(_girl.GirlName);
        _requredLove = _girl.LoveHealth;
        _loveField.UpdateValue(_progress);
        _loveField.gameObject.SetActive(true);
        particleLoveObj.gameObject.SetActive(true);
    }

    public override bool UpdateState(int click)
    {
        _progress = Mathf.Clamp(_progress + click, _progress, _requredLove);
        _loveField.UpdateValue(_progress / _requredLove); 
        particleLove.Play();
        _girlSound.PlayVois();
        if (_progress < _requredLove - _delay)
        {
            UpdateDialog();
        }
        else
        {
            _dialogWindow.ShowDialog(_endWords);
        }
        return _progress < _requredLove;
    }

    public override void Exit()
    {
        _loveField.gameObject.SetActive(false);
        _dialogWindow.HideDialog();
        particleLoveObj.gameObject.SetActive(false);
    }

    private void UpdateDialog()
    {
        _delayProgress++;
        if (_delayProgress >= _delay)
        {
            _delayProgress = 0;
            _dialogWindow.ShowDialog(_girl.GetDialog());
        }
    }

}
