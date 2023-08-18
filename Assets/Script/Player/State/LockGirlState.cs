using UnityEngine;

public class LockGirlState : GirlState
{
    [Min(10)]
    [SerializeField] private int _cellHealth;
    [SerializeField] private GirlCell _girlCell;

    private float _progress;

    public override GirlStateType TypeState => GirlStateType.LockState;

    private void Reset()
    {
        _cellHealth = 20;
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
        _girlCell.LoadProgress(_progress / _cellHealth);
    }

    public override void Enter(Girl girl)
    {
        _progress = 0f;
        _girlCell.ShowCell();
        _girlCell.LoadProgress(_progress);
        _cellHealth = girl.Data.CellHealth;
    }

    public override bool UpdateState(int click)
    {
        _progress = Mathf.Clamp(_progress + click, _progress, _cellHealth);
        _girlCell.UpdateProgress(_progress / _cellHealth);
        return _progress < _cellHealth;
    }

    public override void Exit()
    {
        _girlCell.HideCell();
        _girlCell.LoadProgress(1f);
    }

}
