using UnityEngine;
using System.Collections;

public class StatusPanel : MonoBehaviour {
    GameObject PlayerInfo;
    GameObject Diamond;
    GameObject Gold;
    GameObject VIT;
    GameObject SkillPoint;

    UISprite PlayerIcon;
    UILabel PlayerName;
    UILabel PlayerLV;
    UILabel VIPLV;

    UILabel DiamondNum;
    UILabel GoldNum;
    UILabel VITNum;
    UILabel SkillPointNum;

    

    void Awake()
    {
        PlayerInfo = this.transform.FindChild("PlayerInfo").gameObject;
        Diamond = this.transform.FindChild("Diamond").gameObject;
        Gold = this.transform.FindChild("Gold").gameObject;
        VIT = this.transform.FindChild("VIT").gameObject;
        SkillPoint = this.transform.FindChild("SkillPoint").gameObject;

        PlayerIcon = PlayerInfo.transform.FindChild("Icon").GetComponent<UISprite>();
        PlayerName = PlayerInfo.transform.FindChild("NameBG").GetComponentInChildren<UILabel>();
        PlayerLV = PlayerInfo.transform.FindChild("Level").GetComponentInChildren<UILabel>();
        VIPLV = PlayerInfo.transform.FindChild("VIP").GetComponentInChildren<UILabel>();

        DiamondNum = Diamond.GetComponentInChildren<UILabel>();
        GoldNum = Gold.GetComponentInChildren<UILabel>();
        VITNum = VIT.GetComponentInChildren<UILabel>();
        SkillPointNum = SkillPoint.GetComponentInChildren<UILabel>();

        UIEventListener.Get(PlayerInfo).onClick = PlayerIconOnClick;
        UIEventListener.Get(Diamond.transform.FindChild("PlusButton").gameObject).onClick = DiamondButtonClick;
        UIEventListener.Get(Gold.transform.FindChild("PlusButton").gameObject).onClick = GoldButtonClick;
        UIEventListener.Get(VIT.transform.FindChild("PlusButton").gameObject).onClick = VITButtonClick;

        //changeAbility();

    }

    void changeAbility()
    {
        PlayerIcon.spriteName = "";
        
    }


    void test()
    {
        PlayerName.text = "ABC";
        PlayerLV.text = "ABC";
        VIPLV.text = "ABC";
        DiamondNum.text = "ABC";
        GoldNum.text = "ABC";
        VITNum.text = "ABC";
        SkillPointNum.text = "ABC";
    }

    //头像点击事件
    void PlayerIconOnClick(GameObject x)
    {
        print("PlayerIconOnClick");
    }
    //钻石加按钮点击事件
    void DiamondButtonClick(GameObject x)
    {
        print("DiamondButtonClick");
    }
    //金币加按钮点击事件
    void GoldButtonClick(GameObject x)
    {
        print("GoldButtonClick");
    }
    //体力加按钮点击事件
    void VITButtonClick(GameObject x)
    {
        print("VITButtonClick");
    }
}
