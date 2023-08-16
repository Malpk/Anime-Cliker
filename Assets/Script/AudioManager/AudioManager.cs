using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instanceAudio { get; private set; } 
    [SerializeField] private List<AudioClip> _clips;
    private AudioSource audioSource;
    private int _index = 0;
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
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayVois()
    {
        int index = GetRandomVois();
        audioSource.PlayOneShot(_clips[index]);
    }
    private int GetRandomVois()
    {
        _index = Random.Range(0, _clips.Count);
        return _index;
    }
}
 
