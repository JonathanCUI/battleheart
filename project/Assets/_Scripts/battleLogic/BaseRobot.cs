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
	protected bool isTouched = false;//产生碰撞
	//protected bool isRotate = false;
	protected Vector3 moveTargetPoint;
	//protected Quaternion rotateTargetPoint;
	//人物选中光圈
	protected bool selectedHalo=false;
	private LineRenderer walkPath;//
	private Vector3 touchDown;
	
	//指向一个状态实例的指针
	protected IStateMachine m_pStateMachine;
	
	protected int attackDistance;//攻击范围
	protected BattleConfig.AttackType attackType;//攻击类型
	protected int allies;//同盟 0;1
	protected BattleConfig.PriorityStrategy firstPriority;//技能释放第一选择
	protected BattleConfig.PriorityStrategy secondPriority;//技能释放第二选择
	protected string nickname; //名称 
	protected int lifePoint;//生命 
	protected int defence; //防御 
	protected int attack;  //攻击 
	protected int hitOdds; //命中
	protected int escape;  //闪躲 
	protected int attribute;//属性 
	protected int attrEffect;//属性攻击 
	protected int power;     //战斗力

    protected int currentlifepoint;     //当前血量
	
	protected Dictionary<int,BaseRobot> gameTargets;//技能释放的对象

	protected IRobot iSender;


    public virtual int getDamage()
    {
        return 0;
    }

    public int Escape
    {
        get
        {
            return escape;
        }
        set
        {
            escape = value;
        }
    }

    public int HitOdds
    {
        get
        {
            return hitOdds;
        }
        set
        {
            hitOdds = value;
        }
    }

    public int AttrEffect
    {
        get
        {
            return attrEffect;
        }
        set
        {
            attrEffect = value;
        }
    }



    public int Attack
    {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
    }

    public int Defence
    {
        get
        {
            return defence;
        }
        set
        {
            defence = value;
        }
    }


    public int LifePoint
    {
        get
        {
            return lifePoint;
        }
        set
        {
            lifePoint = value;
        }
    }


    public int CurrentLifePoint
    {
        get
        {
            return currentlifepoint;
        }
        set
        {
            currentlifepoint = value;
        }
    }

    



	
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
	
	public IRobot ISender
	{
		get
		{
			return iSender;
		}
		set
		{
			iSender = value;
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
		gameObject.AddComponent ("LineRenderer");
		walkPath = (LineRenderer)gameObject.GetComponent ("LineRenderer"); 
		walkPath.SetWidth(5, 5);
		walkPath.SetVertexCount(2);
		walkPath.SetColors (Color.yellow,Color.yellow);
		walkPath.renderer.enabled = true;
		
		m_transform = this.transform;
		m_transform.Rotate (0,allies==0?90:-90,0);
		moveTargetPoint = m_transform.position;
	}
	
	// Update is called once per frame
	protected void Update () {
		m_pStateMachine.SMUpdate();
		
		updateMovement ();
		
	}
	
	public IStateMachine GetFSM ()
	{
		//返回状态管理机
		return m_pStateMachine;
	}
	
	protected void FixedUpdate(){
		
	}
	
	void OnMouseDown(){
		touchDown = Input.mousePosition;
	}
	
	void OnMouseDrag(){
		if (Vector3.Distance (touchDown, Input.mousePosition) > 10) {
			Vector3 v = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (v);
			RaycastHit hitinfo;
			bool iscast = Physics.Raycast (ray, out hitinfo, Mathf.Infinity, (int)Mathf.Pow (2.0f, (float)LayerMask.NameToLayer ("plane")));
			if (iscast && (int)(hitinfo.point.y) == 0) {
				walkPath.SetVertexCount(2);
				walkPath.SetPosition (0, m_transform.position);
				walkPath.SetPosition (1, hitinfo.point);
				return;
				
			}
		}
	}
	
	void OnMouseUp(){
		if (Vector3.Distance(touchDown,Input.mousePosition)>10) {
			Vector3 v = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (v);
			RaycastHit hitinfo;
			bool iscast = Physics.Raycast (ray,out hitinfo,Mathf.Infinity,(int)Mathf.Pow(2.0f,(float)LayerMask.NameToLayer("plane")));
			if (iscast&& (int)(hitinfo.point.y)==0) {
				walkPath.SetVertexCount(0);
				this.setMoveTowardsPoint(hitinfo.point);
				return;
				
			}
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		//int a = 1;
		
	}


	void OnTriggerEnter(Collider other) {
		BaseRobot[] objs = other.gameObject.GetComponents<BaseRobot>();
		if (objs!=null&&objs.Length>0){
			if(this.allies!=objs[0].Allies){
				isTouched=true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (isTouched)
			isTouched = false;
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

	/**
	 * 初始化robot
	 * */
	public void initIdentity(Ttxt_battle_character_info info){
		this.attackDistance = info.AttackDistance;
		this.attackType = (BattleConfig.AttackType)info.Type;
		this.nickname=info.Name;
		this.lifePoint=info.LifePoint;
        this.currentlifepoint = info.LifePoint;
		this.defence=info.Defence;
		this.attack=info.Attack; 
		this.hitOdds=info.HitOdds;
		this.escape = info.Escape;
		this.attribute = info.Attribute;
		this.attrEffect = info.AttrEffect;
		this.power = info.Power;
		this.firstPriority = (BattleConfig.PriorityStrategy)info.FirstPriority;
		this.secondPriority = (BattleConfig.PriorityStrategy)info.SecondPriority;
		
		this.allies = info.Allies;
		
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

	/**
	 * 位置是否由AI指定
	 * */
    public bool AiPointed()
    {
        return aiPointed;
    }

	public bool isMeetingEnemy(){
		if (isTouched) {

		}

		return false;
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

	/**
	 * 设置控制寻位点
	 * */
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

	/**
	 * 设置AI寻位点
	 * */
	public void setAITowardsPoint(Vector3 target){
		this.m_transform.LookAt (target);
		moveTargetPoint = target;
		isPointed = false;
		aiPointed = true;
		
	}
    //角色死亡销毁目标
    

	/**
	 * 销毁自身
	 * */
    public void sendDestoryMessage(float deathtime=5)
    {
		if (iSender != null)
			iSender.removeObject (this.m_ID,deathtime);
		//this.gameObject.SendMessageUpwards ("removeRobot",this.m_ID);
	}
}
