using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    public UIButton btnClose;
    public UISlider sliderMusic;
    public UISlider sliderSound;
    public UIToggle togMusic;
    public UIToggle togSound;
    public override void Init()
    {
        btnClose.onClick.Add(new EventDelegate(()=>{HideMe();}));
        sliderMusic.onChange.Add(new EventDelegate(() =>
        {
            GameDataManager.Instance.SetMusicValue(sliderMusic.value);
        }));
        sliderSound.onChange.Add(new EventDelegate(() =>
        {
            GameDataManager.Instance.SetSoundValue(sliderSound.value);
        }));
        togMusic.onChange.Add(new EventDelegate(() =>
        {
            GameDataManager.Instance.SetMusicIsOpen(togMusic.value);
        }));
        togSound.onChange.Add(new EventDelegate(() =>
        {
            GameDataManager.Instance.SetSoundIsOpen(togSound.value);
        }));
        
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        MusicData musicData = GameDataManager.Instance.musicData;
        togMusic.value = musicData.musicIsOpen;
        togSound.value = musicData.soundIsOpen;
        sliderMusic.value = musicData.musicValue;
        sliderSound.value = musicData.soundValue;
    }

    public override void HideMe()
    {
        base.HideMe();
        GameDataManager.Instance.SaveMusicData();
    }
}
