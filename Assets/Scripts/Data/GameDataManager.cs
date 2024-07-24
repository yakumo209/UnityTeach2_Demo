using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private static GameDataManager instance = new GameDataManager();
    public static GameDataManager Instance => instance;

    public MusicData musicData;
    private GameDataManager()
    {
        musicData = XmlDataMgr.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
    }

    public void SaveMusicData()
    {
        XmlDataMgr.Instance.SaveData(musicData,"MusicData");
    }

    public void SetMusicIsOpen(bool isOpen)
    {
        musicData.musicIsOpen = isOpen;
        BkMusic.Instance.SetBkMusicIsOpen(isOpen);
    }
    public void SetSoundIsOpen(bool isOpen)
    {
        musicData.soundIsOpen = isOpen;
        
    }

    public void SetMusicValue(float value)
    {
        musicData.musicValue = value;
        BkMusic.Instance.SetBkMusicValue(value);
    }
    public void SetSoundValue(float value)
    {
        musicData.soundValue = value;
        
    }
}
