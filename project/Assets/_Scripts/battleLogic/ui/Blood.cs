using UnityEngine;
using System.Collections;

public class Blood : MonoBehaviour {

    BaseRobot hero;
    UISlider blood;
    bool iscreate=false;

    void Awake()
    {
        blood = this.GetComponent<UISlider>();
    }
    void Update()
    {
        if (iscreate)
        {
            if (hero.CurrentLifePoint<=0)
            {
                Destroy(this.gameObject);
            }
            blood.value = (float)hero.CurrentLifePoint / (float)hero.LifePoint;
        }
    }

    public void BloodCreate(BaseRobot herox)
    {
        hero = herox;
        if (hero.Allies == 1)
        {
            this.gameObject.transform.FindChild("nowBlood").GetComponent<UISprite>().spriteName = "Blood_red";
        }
        this.gameObject.GetComponent<UIFollowTarget>().target = herox.gameObject.transform.FindChild("bloodposition");
        iscreate = true;
    }

}
