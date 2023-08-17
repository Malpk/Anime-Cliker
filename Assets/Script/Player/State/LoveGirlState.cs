using UnityEngine;

public class LoveGirlState : GirlState
{
    [Min(10)]
    [SerializeField] private int _requredLove;
    [SerializeField] private FieldUI _loveField;

    private float _progress;

    private void Reset()
    {
        _requredLove = 20;
    }

    public override void Enter(Girl girl)
    {
        _progress = 0;
        _requredLove = girl.Data.LoveHealth;
        _loveField.UpdateValue(_progress);
        _loveField.gameObject.SetActive(true);
    }

    public override bool UpdateState(int click)
    {
        _progress = Mathf.Clamp(_progress + click, _progress, _requredLove);
        _loveField.UpdateValue(_progress / _requredLove);
        return _progress < _requredLove;
    }

    public override void Exit()
    {
        _loveField.gameObject.SetActive(false);
    }

}
