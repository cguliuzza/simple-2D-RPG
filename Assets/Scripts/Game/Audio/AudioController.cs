using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioController : BaseSingletonBehaviour<AudioController>
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public List<AudioData> audioData ;
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  PlayBGM(AudioIdentifier id)
    {
        AudioClip clip = audioData.Find(c => c.audioIdentifier == id).audioClip;
        if (clip)
        {
            PlayBGM(clip);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioIdentifier id)
    {
        AudioClip clip = audioData.Find(c => c.audioIdentifier == id).audioClip;
        if (clip)
        {
            PlaySFX(clip);
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void StopBGM()
    {
        musicSource.Stop();
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
