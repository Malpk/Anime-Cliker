using UnityEngine;

public abstract class GirlState : MonoBehaviour
{
    [SerializeField] private GirlState _nextState;

    public abstract void Enter(Girl girl);
    public abstract bool UpdateState(int click);
    public abstract void Exit();
    
    public GirlState GetNextState()
    {
        return _nextState;
    }
}
