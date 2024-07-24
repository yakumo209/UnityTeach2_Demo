using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPanel : BasePanel<BeginPanel>
{
    public UIButton btnBegin;
    public UIButton btnRank;
    public UIButton btnSetting;
    public UIButton btnQuit;
    public override void Init()
    {
        btnBegin.onClick.Add(new EventDelegate(() =>
        {
            //显示选角色面板
            //隐藏自己
            HideMe();
        }));
        btnRank.onClick.Add(new EventDelegate(() =>
        {
            //显示排行榜
            RankPanel.Instance.ShowMe();
        }));
        btnSetting.onClick.Add(new EventDelegate(() =>
        {
            //显示设置面板
            SettingPanel.Instance.ShowMe();
        }));
        btnQuit.onClick.Add(new EventDelegate(() =>
        {
            //退出
            Application.Quit();
        }));
    }

   
}
