using UnityEngine;

public class Girl : MonoBehaviour
{
    [SerializeField] private GirlData _data;
    [SerializeField] private GirlState[] _states;

    private GirlState _curretState;

    public GirlData Data => _data;

    private void Awake()
    {
        foreach (var state in _states)
        {
            state.Exit();
        }
    }

    private void Start()
    {
        SetGirl(_data);
    }

    public void SetGirl(GirlData data)
    {
        Destroy(_data.gameObject);
        _data = Instantiate(data.gameObject, transform.position, 
            Quaternion.identity, transform).GetComponent<GirlData>();
        SetState(_states[0]);
    }

    public void UpdateGirl(int click)
    {
        if (!_curretState.UpdateState(click))
        {
            _curretState.Exit();
            SetState(_curretState.GetNextState());
        }
    }

    private void SetState(GirlState state)
    {
        _curretState?.Exit();
        _curretState = state;
        _curretState.Enter(this);
    }
}
