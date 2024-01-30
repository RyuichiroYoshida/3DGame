using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _medalAudioSource;
    [SerializeField] private AudioClip _medalDropClip;
    
    public void AMedalDrop()
    {
        _medalAudioSource.PlayOneShot(_medalDropClip);
    }
}