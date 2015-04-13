using UnityEngine;
using System.Collections;

public class Skillbutton: MonoBehaviour {
    float NowCD=0;              //当前冷却时间
    float MaxCD=60;             //总冷却时间
    private UISprite SkillIcon;       //技能图标
    private UISprite CDSprite;           //CD图标
    private UISprite layer;             //罩子
    private UISprite DeathLabel;        //精灵死亡后显示“死亡”信息
    private UILabel TimeLabel;           //时间显示


    private bool isClick=false;         //是否按下了技能
    private bool isCD = false;          //是否正在CD

    void Awake()
    {
        SkillIcon = this.transform.FindChild("SkillIcon").GetComponent<UISprite>();
        CDSprite = this.transform.FindChild("CD").GetComponent<UISprite>();
        layer = this.transform.FindChild("Layer").GetComponent<UISprite>();
        DeathLabel = this.transform.FindChild("DeathLabel").GetComponent<UISprite>();
        TimeLabel = this.transform.FindChild("TimeLabel").GetComponent<UILabel>();
        UIEventListener.Get(this.gameObject).onClick = SkillButtonClick;


    }


    void SkillButtonClick(GameObject x)
    {
        print("111");
    }

	

    //显示时间方法
    private void ShowTime(float T)
    {
        int minute;
        int second;
        minute = (int)T / 60;
        second = (int)T % 60;
        TimeLabel.text = (minute < 10 ? "0" + minute : "" + minute) + ":" + (second < 10 ? "0" + second : "" + second);
    }

}
