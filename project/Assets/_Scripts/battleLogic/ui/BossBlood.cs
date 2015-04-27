using UnityEngine;
using System.Collections;

public class BossBlood : MonoBehaviour {

    UISlider blood;
    UISprite Icon;
    UILabel name;
    UILabel layer;
    UISprite background;
    UISprite Foreground;
    bool iscreated=false;

    int layernumber;
    Color[] colors = { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.grey, Color.white,Color.black };
    int maxHP;
    int NowHP;

    void Awake()
    {
        blood = this.GetComponent<UISlider>();
        Icon = this.transform.FindChild("Icon").GetComponent<UISprite>();
        name = this.transform.FindChild("NameLabel").GetComponent<UILabel>();
        layer = this.transform.FindChild("Layer").GetComponent<UILabel>();
        background = this.GetComponent<UISprite>();
        Foreground = this.transform.FindChild("Foreground").GetComponent<UISprite>();
    }

    public void changeall(int maxhp,int layern=1,string iconid="Monster1",string name="老喷")
    {
        Icon.spriteName = iconid;
        this.name.text = name;
        if (layern > 1)
        {
            this.layer.text = "x" + layern;
        }
        else
        {
            this.layer.text = "";
        }

        maxHP = maxhp;
        NowHP = maxhp;
        layernumber = layern;
        iscreated = true;
    }

    void Update()
    {
        if (iscreated)
        {
            NowHP--;
            bloodshow();
        }
    }

    void bloodshow()
    {

        int nowlayer = (int)((float)NowHP / (float)maxHP * layernumber);
        if (NowHP >= 0)
        {
            blood.value = ((float)NowHP - (float)nowlayer * (float)maxHP / (float)layernumber) / ((float)maxHP / (float)layernumber);
            if (nowlayer >= 0)
            {
                background.color = colors[colors.Length - nowlayer-1];
                Foreground.color = colors[colors.Length - nowlayer-2];
            }
            if (nowlayer >= 1)
            {
                this.layer.text = "x" + (nowlayer+1);
            }
            else
            {
                this.layer.text = "";
            }
        }
    }




}
