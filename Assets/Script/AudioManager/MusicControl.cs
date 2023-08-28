using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    private AudioManager audio;
    [SerializeField] private AudioClip[] audioArray;
    [SerializeField] private float _volumeMus = 1;
    [SerializeField] private Slider musicVolumeSlider;

    private Coroutine _corotine;
    private bool isPlaying = false;
    private int index = 0;

    private AudioSource m_AudioSource;

    private void Awake()
    { 
        m_AudioSource = gameObject.AddComponent<AudioSource>(); 
    }

    private IEnumerator Start() 
    {
        audio = AudioManager.instanceAudio;
        if (!isPlaying)
            PlayNextMusic();
        yield return null;
    }
    private void Update()
    { 
        _volumeMus = musicVolumeSlider.value;
        m_AudioSource.volume = _volumeMus;
    }
    private void PlayNextMusic()
    { 
        m_AudioSource.PlayOneShot(audioArray[index]);
        _corotine = StartCoroutine(WaitForMusicToFinish());
    }
    private IEnumerator WaitForMusicToFinish()
    {
        isPlaying = true;

        while (m_AudioSource.isPlaying)
        {
            yield return null;
        }

        isPlaying = false;
        index++;
        if (index >= audioArray.Length)
            index = 0;
        PlayNextMusic();
    }
    private void OnApplicationFocus(bool hasFocus)  
    {
        Silence(!hasFocus);
    }

    private void OnApplicationPause(bool isPaused) 
    {
        Silence(isPaused);
    }
    private void Silence(bool silence)
    {
        AudioListener.pause = silence;
        // Or / And
        AudioListener.volume = silence ? 0 : 1;
    } 
   
    public void PouseMusic()
    {
        enabled = false;
        m_AudioSource.Stop();
        if (_corotine != null)
        {
            StopCoroutine(_corotine);
            _corotine = null;
        }
        StopAllCoroutines();
        isPlaying = false;
        audio.audioSource.volume = 0;
    }
    public void PlayingMusic()
    {
        enabled = true;
        if (!isPlaying)
            m_AudioSource.Play();
        audio.audioSource.volume = 0.25f;
    }
    public void SetMusicVolume(float volume)
    {
        _volumeMus = volume;
    }
}
