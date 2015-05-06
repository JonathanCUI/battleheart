using UnityEngine;
using System.Collections;

public class MainStageUIManager : MonoBehaviour {

    GameObject UIRoot;

    //GameObject Team;
    //GameObject Package;
    //GameObject Chip;
    //GameObject Mission;
    //GameObject Mail;
    //GameObject Arena;
    //GameObject SD;
    //GameObject BattleButton;



    void Awake()
    {
        UIRoot = this.gameObject.transform.parent.gameObject;
        GameObject Team = UIRoot.transform.FindChild("Team").gameObject;
        GameObject Package = UIRoot.transform.FindChild("Package").gameObject;
        GameObject Chip = UIRoot.transform.FindChild("Chip").gameObject;
        GameObject Mission = UIRoot.transform.FindChild("Mission").gameObject;
        GameObject Mail = UIRoot.transform.FindChild("Mail").gameObject;
        GameObject Arena = UIRoot.transform.FindChild("Arena").gameObject;
        GameObject SD = UIRoot.transform.FindChild("SD").gameObject;
        GameObject BattleButton = UIRoot.transform.FindChild("BattleButton").gameObject;

        UIEventListener.Get(Team).onClick = TeamOnClick;
        UIEventListener.Get(Team.transform.GetChild(0).gameObject).onClick = TeamOnClick;
        UIEventListener.Get(Package).onClick = PackageOnClick;
        UIEventListener.Get(Package.transform.GetChild(0).gameObject).onClick = PackageOnClick;
        UIEventListener.Get(Chip).onClick = ChipOnClick;
        UIEventListener.Get(Chip.transform.GetChild(0).gameObject).onClick = ChipOnClick;
        UIEventListener.Get(Mission).onClick = MissionOnClick;
        UIEventListener.Get(Mission.transform.GetChild(0).gameObject).onClick = MissionOnClick;
        UIEventListener.Get(Mail).onClick = MailOnClick;
        UIEventListener.Get(Arena).onClick = ArenaOnClick;
        UIEventListener.Get(SD).onClick = SDOnClick;
        UIEventListener.Get(BattleButton).onClick = BattleButtonOnClick;


		Application.LoadLevel ("battle");
    }

    void TeamOnClick(GameObject x)
    {
        print("TeamOnClick");
    }

    void PackageOnClick(GameObject x)
    {
        print("PackageOnClick");
    }
    void ChipOnClick(GameObject x)
    {
        print("ChipOnClick");
    }

    void MissionOnClick(GameObject x)
    {
        print("MissionOnClick");
    }
    void MailOnClick(GameObject x)
    {
        print("MailOnClick");
    }
    void ArenaOnClick(GameObject x)
    {
        print("ArenaOnClick");
    }
    void SDOnClick(GameObject x)
    {
        print("SDOnClick");
    }
    void BattleButtonOnClick(GameObject x)
    {
        print("BattleButtonOnClick");
    }




}
