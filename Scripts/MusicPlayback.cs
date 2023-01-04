using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayback : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip[] myAudioClips;

    private static MusicPlayback instance = null;
    public static MusicPlayback Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (MusicPlayback)FindObjectOfType(typeof(MusicPlayback));
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(Instance != this)
        {
            Destroy(transform.gameObject);
        }    
        DontDestroyOnLoad(transform.gameObject);
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayCards()
    {
        if (myAudioSource.clip != myAudioClips[0])
        {
            myAudioSource.Stop();
            myAudioSource.clip = myAudioClips[0];
        }
        if (myAudioSource.isPlaying) return;
        myAudioSource.Play();
    }

    public void PlayDate()
    {
        if (!myAudioSource.isPlaying || myAudioSource.clip != myAudioClips[1])
        {
            myAudioSource.Stop();
            myAudioSource.clip = myAudioClips[1];
        }
        myAudioSource.Play();
    }

    public void StopMusic()
    {
        myAudioSource.Stop();
    }
}
