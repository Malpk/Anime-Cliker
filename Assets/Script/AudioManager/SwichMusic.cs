using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwichMusic : MonoBehaviour
{
    [SerializeField]  private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] audioArray;
    [SerializeField] private float _volumeMus = 1;
    [SerializeField] private Slider musicVolumeSlider;
    private int index = 0;
    private bool isPlaying = false;

    private void Awake()
    { 
        m_AudioSource = gameObject.AddComponent<AudioSource>(); 
    }

    private IEnumerator Start()
    {
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
        m_AudioSource.clip = audioArray[index];
        m_AudioSource.Play();
        StartCoroutine(WaitForMusicToFinish());
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

    public void TurnOnMusic()
    {
        if (!isPlaying)
            PlayNextMusic();
    }

    public void TurnOffMusic()
    {
        m_AudioSource.Stop();
        StopAllCoroutines();
        isPlaying = false;
    }
    public void SetMusicVolume(float volume)
    {
        _volumeMus = volume;
    }
}
