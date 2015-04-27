using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 
 * AI implementation with state design pattern
 **/

public class BaseRobot : MonoBehaviour {

	protected Transform m_transform;
	protected float m_speed = 100;//移动速度
	protected float s_speed = 0.1f;//旋转速度

	protected bool isPointed = false;//玩家控制移动指向
	protected bool aiPointed = false;//ai控制移动指向
	//protected bool isRotate = false;
	protected Vector3 moveTargetPoint;
	//protected Quaternion rotateTargetPoint;
	//人物选中光圈
	protected bool selectedHalo=false;

	//指向一个状态实例的指针
	protected IStateMachine m_pStateMachine;

	protected int attackDistance;//攻击范围
	protected BattleConfig.AttackType attackType;//攻击类型
	protected int allies;//同盟 0;1
	protected BattleConfig.PriorityStrategy firstPriority;//技能释放第一选择
	protected BattleConfig.PriorityStrategy secondPriority;//技能释放第二选择
	protected string name; //名称 
	protected int lifePoint;//生命 
	protected int defence; //防御 
	protected int attack;  //攻击 
	protected int hitOdds; //命中
	protected int escape;  //闪躲 
	protected int attribute;//属性 
	protected int attrEffect;//属性攻击 
	protected int power;     //战斗力

	protected Dictionary<int,BaseRobot> gameTargets;//技能释放的对象
	

	public int AttackDistance 
	{
		get 
		{ 
			return attackDistance; 
		}
		set 
		{
			attackDistance = value; 
		}
	}
	public BattleConfig.AttackType AttackType 
	{
		get 
		{ 
			return attackType; 
		}
		set 
		{
			attackType = value; 
		}
	}
	public int Allies 
	{
		get 
		{ 
			return allies; 
		}
		set 
		{
			allies = value; 
		}
	}
	public BattleConfig.PriorityStrategy FirstPriority 
	{
		get 
		{ 
			return firstPriority; 
		}
		set 
		{
			firstPriority = value; 
		}
	}
	public BattleConfig.PriorityStrategy SecondPriority 
	{
		get 
		{ 
			return secondPriority; 
		}
		set 
		{
			secondPriority = value; 
		}
	}

	public Dictionary<int,BaseRobot> GameTargets 
	{
		get 
		{ 
			return gameTargets; 
		}
		set 
		{
			gameTargets = value; 
		}
	}

	

	private int m_ID;//unique serial number for each object
	
	private static ArrayList m_idArray = new ArrayList();

	public void SetID (int val)
	{
		if (m_idArray.Contains(val)) {
			return;
		}

		m_idArray.Add(val);
		m_ID = val;
	}
	
	public int getID(){
		return m_ID;
	}


	// Use this for initialization
	protected void Start () {
		(gameObject.GetComponent ("Halo") as Behaviour).enabled = false;
		m_transform = this.transform;
		m_transform.Rotate (0,allies==0?90:-90,0);
		moveTargetPoint = m_transform.position;
	}
	
	// Update is called once per frame
	protected void Update () {
		m_pStateMachine.SMUpdate();
		updateMovement ();
//		isOjbSelected ();
	}

	public IStateMachine GetFSM ()
	{
		//返回状态管理机
		return m_pStateMachine;
	}

	protected void FixedUpdate(){

	}
	/**
	 * 初始化robot
	 * */
	public void initIdentity(int atkdistance,BattleConfig.AttackType atkType,int al,BattleConfig.PriorityStrategy firstPri,BattleConfig.PriorityStrategy secondPri){
		this.attackDistance = atkdistance;
		this.attackType = atkType;
		this.allies = al;
		this.firstPriority = firstPri;
		this.secondPriority = secondPri;
	}

	public void initIdentity(Ttxt_battle_character_info info){
		this.attackDistance = info.AttackDistance;
		//this.attackType = atkType;
		this.allies = info.Allies;
		//this.firstPriority = firstPri;
		//this.secondPriority = secondPri;
	}

	public virtual void changeState(IState state){

	}

	/**
	 * update movement
	 * */
	void updateMovement(){

		if (isPointed||aiPointed){
			Vector3 pos = Vector3.MoveTowards (this.m_transform.position,moveTargetPoint,m_speed * Time.deltaTime);
			m_transform.Translate(pos, Space.World);
			m_transform.position = pos;
			if(m_transform.position==moveTargetPoint){
				isPointed=false;
				aiPointed=false;
				m_transform.rotation=Quaternion.RotateTowards(m_transform.rotation,Quaternion.Euler(new Vector3(0,allies==0?90:-90,0)),360);//转向正前方
			}else{
			}

	    }

	}


    void isOjbSelected(){
		if (Input.GetMouseButtonDown (0)) {
			Vector3 ms = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (ms);
			RaycastHit hitinfo;
			bool iscast = Physics.Raycast (ray,out hitinfo,Mathf.Infinity);
			if (iscast) {
				selectedHalo=true;
				return;

			}

		}
		selectedHalo = false;
	}

	/**
	 * 位置是否由玩家指定
	 * */
	public bool userPointed(){
		return isPointed;
	}

	public void playAnimation(string name){
		
		animation.Play (name);
	}

	public Vector3 getPosition(){
		return this.m_transform.position;
	}

	public void setHalo(bool selected){
		selectedHalo = selected;
		(gameObject.GetComponent ("Halo") as Behaviour).enabled = selectedHalo;
	}

	public void setMoveTowardsPoint(Vector3 target){
//      float z = target.z - this.transform.position.z;
//		float x = target.x - this.transform.position.x;
//		float a = Mathf.Atan2(z, x) * (-180) / Mathf.PI;
//		this.m_transform.Rotate (new Vector3 (0, a, 0));
        //StartCoroutine(setrotation(this.transform.eulerAngles.y, a, this.gameObject, target));
		this.m_transform.LookAt (target);
		moveTargetPoint = target;
		aiPointed = false;
		isPointed = true;

		
	}
	public void setAITowardsPoint(Vector3 target){
		this.m_transform.LookAt (target);
		moveTargetPoint = target;
		isPointed = false;
		aiPointed = true;

	}
	
}
