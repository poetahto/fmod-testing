using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField, EventRef] private string thudSound = default;
    [SerializeField, EventRef] private string coolMusic = default;
    
    private bool _playingMusic = false;
    private float _volume = 1f;
    private Bus _musicBus;
    private EventInstance _music;
    
    private void Start()
    {
        _musicBus = RuntimeManager.GetBus("bus:/");
        _music = RuntimeManager.CreateInstance(coolMusic);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 100, 0, 100, 100));
        
        if (GUILayout.Button("Play thud"))
            RuntimeManager.PlayOneShot(thudSound);

        if (GUILayout.Toggle(_playingMusic, "Play music") != _playingMusic)
        {
            _playingMusic = !_playingMusic;

            if (_playingMusic)
            {
                _music.start();
            }
            else
            {
                _music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }

        }

        GUILayout.Label("Volume");
        _volume = GUILayout.HorizontalSlider(_volume, 0f, 1f);
        _musicBus.setVolume(_volume);
        
        GUILayout.EndArea();
    }
}
