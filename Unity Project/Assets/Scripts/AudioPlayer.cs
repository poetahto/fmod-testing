using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField, EventRef] private string thudSound = default;
    
    private bool _playingMusic = false;
    private float _volume = 1f;
    private Bus _musicBus;

    private void Start()
    {
        _musicBus = RuntimeManager.GetBus("bus:/Master");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Play thud"))
            RuntimeManager.PlayOneShot(thudSound);

        if (GUILayout.Toggle(_playingMusic, "Play music") != _playingMusic)
        {
            _playingMusic = !_playingMusic;
            // set music playing to _playingMusic
        }

        GUILayout.Label("Volume");
        _volume = GUILayout.HorizontalSlider(_volume, 0f, 1f);
        _musicBus.setVolume(_volume);
    }
}
