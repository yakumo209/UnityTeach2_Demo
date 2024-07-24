using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkMusic : MonoBehaviour
{
    private static BkMusic instance;
    public static BkMusic Instance=>instance;


    private AudioSource bkAudio;
    private void Awake()
    {
        instance = this;
        bkAudio = GetComponent<AudioSource>();
        SetBkMusicValue(GameDataManager.Instance.musicData.musicValue);
        SetBkMusicIsOpen(GameDataManager.Instance.musicData.musicIsOpen); 
    }

    public void SetBkMusicIsOpen(bool isOpen)
    {
        bkAudio.mute = !isOpen;
    }

    public void SetBkMusicValue(float value)
    {
        bkAudio.volume = value;
    }
}
