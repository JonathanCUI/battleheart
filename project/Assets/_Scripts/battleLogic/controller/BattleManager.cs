using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 *  Desmond
 * controlling battle scene and AI logic of game characters
 * */
public class BattleManager : MonoBehaviour {

	public GameObject heroTemplate;//创建robot prefab模板

	private int layerMask;//点击射线碰撞层id
	private int increasingID=0;//自增id
	private int controllingID=-1;//当前选中robot id

	Dictionary<int,BaseRobot> heroMap =new Dictionary<int, BaseRobot>();
	
	void Start () {
		layerMask  = (int)Mathf.Pow(2.0f,(float)LayerMask.NameToLayer("plane"));

		createCharaters ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 ms = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (ms);
			RaycastHit hitinfo;
			bool iscast = Physics.Raycast (ray,out hitinfo,Mathf.Infinity,layerMask);
			if (iscast) {
				Debug.Log(hitinfo.collider.gameObject.name);
				BaseRobot robot = (BaseRobot)hitinfo.collider.gameObject.GetComponent<HeroRobot> ();
				if(robot!=null){
					if(this.controllingID==robot.getID()){//取消选中点击
						robot.setHalo(false);
						this.controllingID=-1;
					}else{//选中点击
						if(heroMap.ContainsKey(controllingID)){
							heroMap[controllingID].setHalo(false);
						}
					    robot.setHalo(true);
						this.controllingID=robot.getID();
					}
				}
				else{
					if(heroMap.ContainsKey(controllingID)){
						robot=heroMap[controllingID];
					    robot.setMoveTowardsPoint(hitinfo.point);
					}

				}
			}
			
		}
	}

	private void createCharaters(){
		int unit = 10;
		int offset = 1000;
		//生命补助
		GameObject obj = (GameObject)Instantiate (heroTemplate, new Vector3 (0-offset, 0, 7*unit), Quaternion.identity);
		BaseRobot robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		robot.initIdentity (-1, BattleConfig.AttackType.SUPPORT, 0, BattleConfig.PriorityStrategy.SELF_LIFE, BattleConfig.PriorityStrategy.LEAST_LIFE);
		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//效果补助
		obj = (GameObject)Instantiate (heroTemplate, new Vector3 ((10*unit-offset), 0, -7*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		robot.initIdentity (-1, BattleConfig.AttackType.SUPPORT, 0, BattleConfig.PriorityStrategy.SELF_EFFECT, BattleConfig.PriorityStrategy.NO_EFFECT);
		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//远程法师
		obj = (GameObject)Instantiate (heroTemplate, new Vector3 (20*unit-offset, 0, 12*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		robot.initIdentity (1000, BattleConfig.AttackType.LONG, 0, BattleConfig.PriorityStrategy.SHORT, BattleConfig.PriorityStrategy.CLOSTEST);
		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//远程物攻
		obj = (GameObject)Instantiate (heroTemplate, new Vector3 (30*unit-offset, 0, -5*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		robot.initIdentity (1000, BattleConfig.AttackType.LONG, 0, BattleConfig.PriorityStrategy.LONG, BattleConfig.PriorityStrategy.CLOSTEST);
		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//刺客
		obj = (GameObject)Instantiate (heroTemplate, new Vector3 (40*unit-offset, 0, 12*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		robot.initIdentity (100, BattleConfig.AttackType.SHORT, 0, BattleConfig.PriorityStrategy.LONG, BattleConfig.PriorityStrategy.CLOSTEST);
		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);

		//肉盾
		obj = (GameObject)Instantiate (heroTemplate, new Vector3 (50*unit-offset, 0, 5*unit), Quaternion.identity);
		robot = (BaseRobot)obj.GetComponent<HeroRobot> ();
		robot.initIdentity (100, BattleConfig.AttackType.SHORT, 0, BattleConfig.PriorityStrategy.SHORT, BattleConfig.PriorityStrategy.CLOSTEST);
		robot.SetID (increasingID++);
		//robot.gameObject.layer = layerMask;
		heroMap.Add (robot.getID (), robot);
	}

  


}
