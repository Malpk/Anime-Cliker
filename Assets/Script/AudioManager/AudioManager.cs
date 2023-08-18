using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instanceAudio { get; private set; }
    
    [Min(0)]
    [SerializeField] private int _delay;

    [SerializeField] private List<AudioClip> _clipsGirle;
    [SerializeField] private List<AudioClip> _clipsMan; 

    [SerializeField] private AudioClip ironLock;
    [SerializeField] private AudioClip clipPicup;

    [SerializeField] private float volume = 1; 

    private int _index = 0;
    private float _progress = 0;
    private AudioSource audioSource; 
    private void Reset()
    {
        _delay = 9;
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
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = volume; 
    }
    public void PlayLockIron()
    {
        audioSource.PlayOneShot(ironLock,1f); 
    }
    public void PlayPicupVois()
    {
        audioSource.PlayOneShot(clipPicup, 1f);
    }
    public void PlayVoisMan()
    { 
        int index = Random.Range(0, 2);
        audioSource.PlayOneShot(_clipsMan[index]);
    }
    public void PlayVois()
    {
        _progress++;
        if (_progress > _delay)
        {
            _progress = 0f;
            int index = GetRandomVois();
            audioSource.PlayOneShot(_clipsGirle[index]);
        }
    }
    private int GetRandomVois()
    {   
        _index = Random.Range(0, _clipsGirle.Count);
        return _index;
    }
}
 
