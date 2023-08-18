using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instanceAudio { get; private set; }
    
    [Min(0)]
    [SerializeField] private int _delay;
    [SerializeField] private List<AudioClip> _clips;
    [SerializeField] private AudioClip ironLock;
    
    private int _index = 0;
    private float _progress = 0;
    private AudioSource audioSource;

    private void Reset()
    {
        _delay = 3;
    }

    private void Awake()
    {
        if (instanceAudio == null)
        {
            instanceAudio = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
            return;
        }
        _progress = _delay;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayLockIron()
    {
        audioSource.PlayOneShot(ironLock,1f);
    }
    public void PlayVois()
    {
        _progress++;
        if (_progress > _delay)
        {
            _progress = 0f;
            int index = GetRandomVois();
            audioSource.PlayOneShot(_clips[index]);
        }
    }
    private int GetRandomVois()
    {
        _index = Random.Range(0, _clips.Count);
        return _index;
    }
}
 
