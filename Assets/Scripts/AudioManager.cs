using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _medalAudioSource;
    [SerializeField] private AudioClip _medalDropClip;
    [SerializeField] private AudioSource _chanceAudio;
    [SerializeField] private AudioSource _fiverBGM;
    [SerializeField] private AudioSource _bombExplosion;
    [SerializeField] private AudioSource _bonusAudio;
    [SerializeField] private AudioSource _fiverDropMedal;

    public AudioSource ChanceAudio => _chanceAudio;
    public AudioSource FiverBGM => _fiverBGM;

    public AudioSource BombExplosion => _bombExplosion;

    public AudioSource BonusAudio => _bonusAudio;

    public AudioSource FiverDropMedal => _fiverDropMedal;

    public void AMedalDrop()
    {
        _medalAudioSource.PlayOneShot(_medalDropClip);
    }
}