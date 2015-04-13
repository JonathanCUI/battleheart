using UnityEngine;
using System.Collections;

public class HUD_blood : MonoBehaviour {
    public GameObject hudblood;//伤害预设
    //用HUD显示伤害
    void bloodhud(string T,int type,Vector3 v3)
    {
        GameObject hudtext = NGUITools.AddChild(this.gameObject, hudblood);
        hudtext.transform.parent = this.transform;
		hudtext.transform.localPosition = v3;
		if (type == 1)
		{
			hudtext.GetComponent<HUDText>().fontSize=60;
				}

        hudtext.GetComponent<HUDText>().Add(T, Color.red, 0.1f);
        Destroy(hudtext, 1f);                       //1s后销毁HUD
    }

}
