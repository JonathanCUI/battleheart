using UnityEngine;
using System.Collections;

public class UIEventCenter : MonoBehaviour {
    //金钱显示
    public static void showGold_msg(int x)
    {
        if (showGoldEvent!=null)
        {
            showGoldEvent(x);
        }
    }
    public delegate void showGoldEventHandler(int x);
    public static event showGoldEventHandler showGoldEvent;


    //宝物显示
    public static void showReward_msg(int x)
    {
        if (showRewardEvent != null)
        {
            showRewardEvent(x);
        }
    }
    public delegate void showRewardEventHandler(int x);
    public static event showRewardEventHandler showRewardEvent;


    //血条显示
    public static void showBlood_msg(BaseRobot x)
    {
        if (showBloodEvent != null)
        {
            showBloodEvent(x);
        }
    }
    public delegate void showBloodEventHandler(BaseRobot x);
    public static event showBloodEventHandler showBloodEvent;




}
