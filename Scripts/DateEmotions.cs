using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateEmotions : MonoBehaviour
{
    public Sprite excitedExpression;
    public Sprite flushedExpression;
    public Sprite neutralExpression;
    public Sprite unhappyExpression;

    private Image goImage;

    public AudioSource myAudioSource;
    public AudioClip[] myAudioClips;

    void Start()
    {
        goImage = gameObject.GetComponent<Image>();


        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayback>().PlayDate();
    }

    public void Excited()
    {
        goImage.sprite = excitedExpression;
        myAudioSource.PlayOneShot(myAudioClips[0]);
        myAudioSource.PlayOneShot(myAudioClips[3]);
    }
    public void Flushed()
    {
        goImage.sprite = flushedExpression;
        myAudioSource.PlayOneShot(myAudioClips[0]);
        myAudioSource.PlayOneShot(myAudioClips[3]);
    }
    public void Neutral()
    {
        goImage.sprite = neutralExpression;
        myAudioSource.PlayOneShot(myAudioClips[1]);
    }
    public void Unhappy()
    {
        goImage.sprite = unhappyExpression;
        myAudioSource.PlayOneShot(myAudioClips[2]);
        myAudioSource.PlayOneShot(myAudioClips[4]);
    }


}
