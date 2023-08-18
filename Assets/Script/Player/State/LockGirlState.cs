using UnityEngine;

public class LockGirlState : GirlState
{
    private AudioManager _girlSound;
    [Min(10)]
    [SerializeField] private int _cellHealth;
    [SerializeField] private GirlCell _girlCell;
    [SerializeField] private ParticleSystem particleLock;
    [SerializeField] private GameObject particleLockObj;
    
    private float _progress;
    private void Start()
    {
        _girlSound = AudioManager.instanceAudio;
        particleLockObj.gameObject.SetActive(true);
        particleLock.Stop(); 
    }

    private void Reset()
    {
        _cellHealth = 20;
    }

    public override void Enter(Girl girl)
    {
        _progress = 0f;
        _girlCell.ShowCell();
        _cellHealth = girl.Data.CellHealth;
        particleLockObj.gameObject.SetActive(true);
    }

    public override bool UpdateState(int click)
    {
        _progress = Mathf.Clamp(_progress + click, _progress, _cellHealth);
        _girlCell.UpdateProgress(_progress / _cellHealth);
        particleLock.Play();
        _girlSound.PlayLockIron();
        return _progress < _cellHealth;
    }

    public override void Exit()
    { 
        _girlCell.HideCell();
        particleLockObj.gameObject.SetActive(false);
    }
}
