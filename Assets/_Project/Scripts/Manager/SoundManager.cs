using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool FXEnabled;
    [SerializeField]public bool _musicEnable;

    [Range(0, 1)]
    [SerializeField] private float _musicVolume;

    [Range(0, 1)]
    [SerializeField] private float _fxVolume;

    [SerializeField] private AudioClip _clearRowSound;
    [SerializeField] private AudioClip _moveSound;
    [SerializeField] private AudioClip _dropSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _backGroundMusic;
    [SerializeField] private AudioSource _backgroundMusicSource;


    private void Start()
    {
        PlayBackGroundMusic(_backGroundMusic);
    }

    private void PlayBackGroundMusic(AudioClip musicclip)
    {
        if (!_musicEnable || _backgroundMusicSource == null || musicclip == null) return;

        _backgroundMusicSource.Stop();
        _backgroundMusicSource.clip = musicclip;
        _backgroundMusicSource.volume = _musicVolume;
        _backgroundMusicSource.loop = true;
        _backgroundMusicSource.Play();
    }

    private void UpdateMusic()
    {
        if(_backgroundMusicSource.isPlaying != _musicEnable)
        {
            if(_musicEnable)
            {
                PlayBackGroundMusic(_backGroundMusic);
            }
            else
            {
                _backgroundMusicSource.Stop();
            }
        }
    }

    public void ToggleMusic()
    {
        _musicEnable=!_musicEnable;
        UpdateMusic();  
    }
}
