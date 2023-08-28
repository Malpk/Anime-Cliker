using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instanceAudio { get; private set; }
    [SerializeField] private Slider voicesVolumeSlider;

    [Min(0)]
    [SerializeField] private int _delay;

    [SerializeField] private List<AudioClip> _girlVoiceClips;
    [SerializeField] private List<AudioClip> _manVoiceClips;
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip ironLock;
    [SerializeField] private AudioClip clipPicup;

    [SerializeField] private float _volume = 1; 

    private int _index = 0;
    private float _progress = 0;
    [HideInInspector]public AudioSource audioSource; 
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
    }
    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void Update()
    {
        _volume = voicesVolumeSlider.value;
        audioSource.volume = _volume;
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
        audioSource.PlayOneShot(_manVoiceClips[index]);
    }
    public void PlayVois()
    {
        _progress++;
        if (_progress > _delay)
        {
            _progress = 0f;
            int index = GetRandomVois();
            audioSource.PlayOneShot(_girlVoiceClips[index]);
        }
        else
        {
            audioSource.PlayOneShot(_click);
        }
    }
    private int GetRandomVois()
    {   
        _index = Random.Range(0, _girlVoiceClips.Count);
        return _index;
    }
    public void SetVoisVolume(float volume)
    {
        _volume = volume;
    }
}
 
