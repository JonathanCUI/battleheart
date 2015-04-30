using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 *  Desmond
 * controlling battle scene and AI logic of game characters
 * */
public class BattleManager : MonoBehaviour {

	public GameObject heroTemplate;//创建robot prefab模板
	public GameObject assassinatorTemp;
	public GameObject manglerTemp;
	public GameObject masterTemp;
	public GameObject medicTemp;
    public GameObject rangerTemp;
    public GameObject PriestTemp;

	private int layerMask;//点击射线碰撞层id
	private int increasingID=0;//自增id
	private int controllingID=-1;//当前选中robot id
	private bool isInit;
	private bool isDraging = false;

	private Dictionary<int,BaseRobot> heroMap =new Dictionary<int, BaseRobot>();
	
	void Start () {
		TxtClassFactory table = new GameClassFactory ();
		table.loadAll ();

		layerMask  = (int)Mathf.Pow(2.0f,(float)LayerMask.NameToLayer("plane"));

		isInit = false;
		createCharaters ();
		updateGameTargets ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isInit){
			foreach(KeyValuePair<int,BaseRobot> kv in heroMap){
				Vector3 nPos=kv.Value.getPosition();
				int allies=kv.Value.Allies;
				kv.Value.setMoveTowardsPoint(new Vector3(nPos.x+(allies==0?1:-1)*450,nPos.y,nPos.z));
			}
			isInit=true;
			return;
		}
//		if (Input.GetMouseButtonDown (0)) {
//			Vector3 ms = Input.mousePosition;
//            RaycastHit uiHit;
//            if (UICamera.currentCamera)
//            {
//                Ray rayui = UICamera.currentCamera.ScreenPointToRay(ms);
//                if (Physics.Raycast(rayui, out uiHit))
//                {
//                    if (uiHit.collider.gameObject.tag == "UI")
//                    {
//                        return;
//                    }
//                }
//            }
//
//
//			Ray ray = Camera.main.ScreenPointToRay (ms);
//			RaycastHit hitinfo;
//			bool iscast = Physics.Raycast (ray,out hitinfo,Mathf.Infinity,layerMask);
//			if (iscast) {
//				Debug.Log(hitinfo.collider.gameObject.name);
//				BaseRobot robot = (BaseRobot)hitinfo.collider.gameObject.GetComponent<HeroRobot> ();
//				if(robot!=null){
//					if(this.controllingID==robot.getID()){//取消选中点击
//						robot.setHalo(false);
//						this.controllingID=-1;
//					}else{//选中点击
//						if(heroMap.ContainsKey(controllingID)){
//							heroMap[controllingID].setHalo(false);
//						}
//					    robot.setHalo(true);
//						this.controllingID=robot.getID();
//					}
//				}
//				else{
//                        if (heroMap.ContainsKey(controllingID))
//                        {
//                            robot = heroMap[controllingID];
//                            robot.setMoveTowardsPoint(hitinfo.point);
//                        }
//				}
//			}
//			
//		}
	}

//	void OnMouseDrag(){
//		print ("5555555555555");
//		isDraging = true;
//	}
//
//	void OnMouseUp(){
//		isDraging = false;
//	}

	/**
	 * 初始场景阵型
	 * */
	private void createCharaters(){
		int unit = 7;
		int leftOffset = 500;
		int rightOffset = 500;

		/*
		 * 己方阵营
		 * */
		//生命补助
        GameObject obj = (GameObject)Instantiate(medicTemp, new Vector3(-40 * unit - leftOffset, 0, 7 * unit), Quaternion.identity);
		BaseRobot robot = (BaseRobot)obj.GetComponent<Medic> ();
		//robot.initIdentity (-1, BattleConfig.AttackType.SUPPORT, 0, BattleConfig.PriorityStrategy.SELF_LIFE, BattleConfig.PriorityStrategy.LEAST_LIFE);

        Ttxt_battle_character_info character_info;
        Ttxt_battle_character_info.DATA.TryGetValue(5001, out character_info);
		character_info.Allies = 0;
        robot.initIdentity(Ttxt_battle_character_info.DATA[5001]);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);


		//效果补助
		obj = (GameObject)Instantiate (PriestTemp, new Vector3 ((-35*unit-leftOffset), 0, -7*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		//robot.initIdentity (-1, BattleConfig.AttackType.SUPPORT, 0, BattleConfig.PriorityStrategy.SELF_EFFECT, BattleConfig.PriorityStrategy.NO_EFFECT);

        Ttxt_battle_character_info.DATA.TryGetValue(6001, out character_info);
		character_info.Allies = 0;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//远程法师
		obj = (GameObject)Instantiate (masterTemp, new Vector3 (-30*unit-leftOffset, 0, 12*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<Master> ();
		//robot.initIdentity (1000, BattleConfig.AttackType.LONG, 0, BattleConfig.PriorityStrategy.SHORT, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(4001, out character_info);
		character_info.Allies = 0;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//远程物攻
		obj = (GameObject)Instantiate (rangerTemp, new Vector3 (-25*unit-leftOffset, 0, -5*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		//robot.initIdentity (1000, BattleConfig.AttackType.LONG, 0, BattleConfig.PriorityStrategy.LONG, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(3001, out character_info);
		character_info.Allies = 0;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//刺客
		obj = (GameObject)Instantiate (assassinatorTemp, new Vector3 (-20*unit-leftOffset, 0, 12*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<Assassinator> ();
		//robot.initIdentity (100, BattleConfig.AttackType.SHORT, 0, BattleConfig.PriorityStrategy.LONG, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(2001, out character_info);
		character_info.Allies = 0;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//肉盾
		obj = (GameObject)Instantiate (manglerTemp, new Vector3 (-15*unit-leftOffset, 0, 5*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<Mangler> ();
		//robot.initIdentity (100, BattleConfig.AttackType.SHORT, 0, BattleConfig.PriorityStrategy.SHORT, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(1001, out character_info);
		character_info.Allies = 0;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		/*
		 * 敌方阵营
		 * */

		//生命补助
		obj = (GameObject)Instantiate (medicTemp, new Vector3 (40*unit+rightOffset, 0, 7*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<Medic> ();
		//robot.initIdentity (-1, BattleConfig.AttackType.SUPPORT, 1, BattleConfig.PriorityStrategy.SELF_LIFE, BattleConfig.PriorityStrategy.LEAST_LIFE);

        Ttxt_battle_character_info.DATA.TryGetValue(5001, out character_info);
		character_info.Allies = 1;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);
		
		//效果补助
		obj = (GameObject)Instantiate (PriestTemp, new Vector3 ((35*unit+rightOffset), 0, -7*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		//robot.initIdentity (-1, BattleConfig.AttackType.SUPPORT, 1, BattleConfig.PriorityStrategy.SELF_EFFECT, BattleConfig.PriorityStrategy.NO_EFFECT);

        Ttxt_battle_character_info.DATA.TryGetValue(6001, out character_info);
		character_info.Allies = 1;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);
		
		//远程法师
		obj = (GameObject)Instantiate (masterTemp, new Vector3 (30*unit+rightOffset, 0, 12*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<Master> ();
		//robot.initIdentity (1000, BattleConfig.AttackType.LONG, 1, BattleConfig.PriorityStrategy.SHORT, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(4001, out character_info);
		character_info.Allies = 1;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);
		
		//远程物攻
		obj = (GameObject)Instantiate (rangerTemp, new Vector3 (25*unit+rightOffset, 0, -5*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		//robot.initIdentity (1000, BattleConfig.AttackType.LONG, 1, BattleConfig.PriorityStrategy.LONG, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(3001, out character_info);
		character_info.Allies = 1;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);
		
		//刺客
		obj = (GameObject)Instantiate (assassinatorTemp, new Vector3 (20*unit+rightOffset, 0, 12*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<Assassinator> ();
		//robot.initIdentity (100, BattleConfig.AttackType.SHORT, 1, BattleConfig.PriorityStrategy.LONG, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(2001, out character_info);
		character_info.Allies = 1;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);
		
		//肉盾
		obj = (GameObject)Instantiate (manglerTemp, new Vector3 (15*unit+rightOffset, 0, 5*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<Mangler> ();
		//robot.initIdentity (100, BattleConfig.AttackType.SHORT, 1, BattleConfig.PriorityStrategy.SHORT, BattleConfig.PriorityStrategy.CLOSTEST);

        Ttxt_battle_character_info.DATA.TryGetValue(1001, out character_info);
		character_info.Allies = 1;
        robot.initIdentity(character_info);

		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);
	}

  
	/**
	 * 为每个玩家设置对手
	 * */
	private void updateGameTargets(){
		foreach(KeyValuePair<int,BaseRobot> kv in heroMap){
			BaseRobot robot = kv.Value;
			Dictionary<int,BaseRobot> opp=new Dictionary<int, BaseRobot>();
			foreach(KeyValuePair<int,BaseRobot> s_kv in heroMap){
				if(s_kv.Key==kv.Key){
					continue;
				}
				if(robot.AttackType==BattleConfig.AttackType.SUPPORT&&s_kv.Value.Allies==robot.Allies
					   ||
				   robot.AttackType!=BattleConfig.AttackType.SUPPORT&&s_kv.Value.Allies!=robot.Allies){

					opp.Add(s_kv.Key,s_kv.Value);
				}
				
			}
			robot.GameTargets=opp;
		}
	}


}
