using UnityEngine;
using System.Collections;

public class BattleUIManager : MonoBehaviour {

    GameObject UIRoot;
    
    //战斗场景UI

    UILabel TimeLimit;          //剩余时间
    UILabel Gold;               //已获得金钱
    UILabel Reward;             //已获得宝箱
    UILabel SstageNum;          //小关卡数（正上方）
    UILabel BstageNum;          //大关卡数（右下角）
    UISlider Process;           //大关卡进程
    UIGrid SkillPanel;          //技能栏

    public GameObject BossBlood;            //boss血量条
    public GameObject SkillButtonPrefeb;          //技能按钮

    float TimeRemaining;        
    bool isstart=false;

    public TextAsset dataherox;
    public static TextAsset dataheroxstatic;
    void Awake()
    {
        UIRoot = this.gameObject.transform.parent.gameObject;
        GameObject StopButton = UIRoot.transform.FindChild("StopButton").gameObject;
        TimeLimit = UIRoot.transform.FindChild("TimeLimit").GetComponentInChildren<UILabel>();
        Gold = UIRoot.transform.FindChild("Gold").GetComponentInChildren<UILabel>();
        Reward = UIRoot.transform.FindChild("Reward").GetComponentInChildren<UILabel>();
        SstageNum = UIRoot.transform.FindChild("SstageNum").GetComponentInChildren<UILabel>();
        BstageNum = UIRoot.transform.FindChild("BstageNum").GetComponentInChildren<UILabel>();
        Process = UIRoot.transform.FindChild("Process").GetComponentInChildren<UISlider>();
        SkillPanel = UIRoot.transform.FindChild("SkillPanel").GetComponentInChildren<UIGrid>();
        //print(UIRoot.transform.FindChild("SkillPanel").GetComponentInChildren<UIPanel>().clipping);
        
        UIEventListener.Get(StopButton).onClick = StopButtonClick;
        TimeLimitShowStart();

        dataheroxstatic = dataherox;
    }


    void Start()
    {
        BigStageShow();
        test();

    }


    void test()
    {

        GameObject go = NGUITools.AddChild(UIRoot, BossBlood);
        go.transform.localPosition = new Vector3(0, 175, 0);
        go.GetComponent<BossBlood>().changeall(700, 7);



        UIEventCenter.showGoldEvent += ShowGold;
        UIEventCenter.showRewardEvent += ShowReward;

        UIEventCenter.showGold_msg(666);
        UIEventCenter.showReward_msg(333);


        SkillAdd();

        processchange();
    }




    void Update()
    {
        if (isstart)
        {
            TimeLimitShow();
        }

    }


    public void SkillAdd()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject gox = NGUITools.AddChild(SkillPanel.gameObject,SkillButtonPrefeb);
            gox.name = "go" + (i + 1);
            

        }

        SkillPanel.Reposition();

    }



    void processchange(float x=0.1f)
    {
        Process.value = x;
    }



    void BigStageShow(string x = "S1-1")
    {
        BstageNum.text = x;
    }

    void SmallStageShow(string x = "2/3")
    {
        SstageNum.text = x;
    }

    //金币、宝物及当前关卡进度显示
    void ShowGold(int x)
    {
        Gold.text = x.ToString();
    }

    void ShowReward(int x)
    {
        Reward.text = x.ToString();
    }





    //剩余时间显示
    void TimeLimitShow()
    {
        TimeRemaining -= Time.deltaTime;
        if (TimeRemaining >= 0)
        {
            int minute;
            int second;
            minute = (int)TimeRemaining / 60;
            second = (int)TimeRemaining % 60;
            TimeLimit.text = (minute < 10 ? "0" + minute : "" + minute) + ":" + (second < 10 ? "0" + second : "" + second);
        }
        else
        {
            TimeOver();
        }
    }
    //时间到时调用方法
    void TimeOver()
    { 
    
    }
    //开始计时
    void TimeLimitShowStart(float x=3600)
    {
        TimeRemaining = x;
        isstart = true;
    }

    //暂停按钮的点击处理方法
    public void StopButtonClick(GameObject StopButton)
    {
        isstart = !isstart;
        if (isstart)
        {
            StopButton.GetComponent<UISprite>().spriteName = "ButtonOn";
        }
        else
        {
            StopButton.GetComponent<UISprite>().spriteName = "ButtonDown";
        }
    }





     
}
