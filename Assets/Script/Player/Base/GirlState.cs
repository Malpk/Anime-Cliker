using UnityEngine;

public abstract class GirlState : MonoBehaviour
{
    [SerializeField] private GirlState _nextState;

    public abstract GirlStateType TypeState { get; }

    public abstract StateData Save();
    public abstract void Load(StateData json);

    public abstract void Enter(Girl girl);
    public abstract bool UpdateState(int click);
    public abstract void Exit();
    
    public GirlState GetNextState()
    {
        return _nextState;
    }
}
