using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instances;
    public AudioSource audioSource;
    public AudioClip blockTouchClip;
    public AudioClip colorBallTouchClip;

    private void Start()
    {
        if(instances != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instances = this;
        }
    }
    public void BlockTouch()
    {
        audioSource.PlayOneShot(blockTouchClip);
    }

    public void ColorBallTouch()
    {
        audioSource.PlayOneShot(colorBallTouchClip);
    }
}
