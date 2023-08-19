using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichMusic : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] audioArray;
    private float volumeIsMusic = 1;
    private int index = 0;
    private bool isPlaying = false;
     

    private IEnumerator Start()
    { 
        PlayNextMusic();
        yield return null;
    }
    private void Update()
    {
        m_AudioSource.volume = volumeIsMusic;
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
    public void SetVolumeMusic(float volume)
    {
        volumeIsMusic = volume;
    }
}
