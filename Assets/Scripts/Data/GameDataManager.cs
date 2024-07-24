using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private static GameDataManager instance = new GameDataManager();
    public static GameDataManager Instance => instance;

    public MusicData musicData;
    public RankData rankData;
    private GameDataManager()
    {
        musicData = XmlDataMgr.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
        rankData=XmlDataMgr.Instance.LoadData(typeof(RankData),"RankData") as RankData;
    }

    #region 音乐音效相关

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

    #endregion


    #region 排行榜相关

    public void AddRankData(string name, int time)
    {
        rankData.rankList.Add(new RankInfo(name,time));
        
        //sort
        rankData.rankList.Sort((a, b) =>
        {
            return a.time > b.time ? -1 : 1;
        });
        
        //remove20+
        if (rankData.rankList.Count>20)
        {
            rankData.rankList.RemoveAt(20);
        }
        XmlDataMgr.Instance.SaveData(rankData,"RankData");
    }

    #endregion
    
    
    
}
