using UnityEngine;

public class LoveGirlState : GirlState
{
    [Min(10)]
    [SerializeField] private int _requredLove;
    [Min(1)]
    [SerializeField] private int _delay = 1;
    [SerializeField] private string _endWords = "������� ���� ������!!!";
    [Header("Reference")]
    [SerializeField] private FieldUI _loveField;
    [SerializeField] private DialogWindow _dialogWindow;

    private int _delayProgress;
    private float _progress;
    private GirlData _girl;

    private void Reset()
    {
        _delay = 3;
        _requredLove = 20;
    }

    public override void Enter(Girl girl)
    {
        _progress = 0;
        _delayProgress = _delay;
        _girl = girl.Data;
        _requredLove = _girl.LoveHealth;
        _loveField.UpdateValue(_progress);
        _loveField.gameObject.SetActive(true);
    }

    public override bool UpdateState(int click)
    {
        _progress = Mathf.Clamp(_progress + click, _progress, _requredLove);
        _loveField.UpdateValue(_progress / _requredLove);
        if (_progress < _requredLove)
        {
            UpdateDialog();
            return true;
        }
        else
        {
            _dialogWindow.ShowDialog(_endWords);
            return _progress > _requredLove + _delay;
        }
    }

    public override void Exit()
    {
        _loveField.gameObject.SetActive(false);
        _dialogWindow.HideDialog();
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
