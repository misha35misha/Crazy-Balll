using System;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance;
    
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _fire;
    [SerializeField] private AudioClip _inBox;
    [SerializeField] private AudioClip _gameover;
    [SerializeField] private AudioClip _button;

    public void PlayFire()
    {
        _audio.PlayOneShot(_fire);
    }
    
    public void PlayInBox()
    {
        _audio.PlayOneShot(_inBox);
    }
    
    public void PlayGameover()
    {
        _audio.PlayOneShot(_gameover);
    }
    
    public void PlayButton()
    {
        _audio.PlayOneShot(_button);
    }

    private void Awake()
    {
        if (!Instance) Instance = this;
    }
}
