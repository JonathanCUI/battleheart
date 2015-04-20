using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * AI implementation with state design pattern
 **/
public class BaseRobot : MonoBehaviour {

	protected Transform m_transform;
	protected float m_speed = 500;//移动速度
	protected float s_speed = 0.1f;//旋转速度

	protected bool isPointed = false;
	//protected bool isRotate = false;
	protected Vector3 moveTargetPoint;
	//protected Quaternion rotateTargetPoint;
	//人物选中光圈
	protected bool selectedHalo=false;

	//指向一个状态实例的指针
	protected StateMachine<HeroRobot> m_pStateMachine;

	protected int attackDistance;//攻击范围
	protected BattleConfig.AttackType attackType;//攻击类型
	protected int allies;//同盟 0;1
	protected BattleConfig.PriorityStrategy firstPriority;//技能释放第一选择
	protected BattleConfig.PriorityStrategy secondPriority;//技能释放第二选择

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
		m_transform.Rotate (0,90,0);
		moveTargetPoint = m_transform.position;

	}
	
	// Update is called once per frame
	protected void Update () {
		m_pStateMachine.SMUpdate();
		updateMovement ();
//		isOjbSelected ();
	}

	/**
	 * 
	 * */
	public void initIdentity(int atkdistance,BattleConfig.AttackType atkType,int al,BattleConfig.PriorityStrategy firstPri,BattleConfig.PriorityStrategy secondPri){
		this.attackDistance = atkdistance;
		this.attackType = atkType;
		this.allies = al;
		this.firstPriority = firstPri;
		this.secondPriority = secondPri;
	}
	/**
	 * update movement
	 * */
	void updateMovement(){
//		if (Input.GetMouseButtonDown (0)) {
//			Vector3 ms = Input.mousePosition;
//			Ray ray = Camera.main.ScreenPointToRay (ms);
//			RaycastHit hitinfo;
//			LayerMask mask = new LayerMask ();
//			mask.value = (int)Mathf.Pow(2.0f,(float)LayerMask.NameToLayer("plane"));
//			bool iscast = Physics.Raycast (ray,out hitinfo,Mathf.Infinity,mask.value);
//			if (iscast) {
//				m_targetPos = hitinfo.point;
//				isPointed=true;
//			}
//
//		}
		if (isPointed){
			Vector3 pos = Vector3.MoveTowards (this.m_transform.position,moveTargetPoint,m_speed * Time.deltaTime);
			m_transform.Translate(pos, Space.World);
			m_transform.position = pos;
			if(m_transform.position==moveTargetPoint){
				isPointed=false;
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
	public void playAnimation(string name){
		
		animation.Play (name);
	}

	public void setHalo(bool selected){
		selectedHalo = selected;
		(gameObject.GetComponent ("Halo") as Behaviour).enabled = selectedHalo;
	}

	public void setMoveTowardsPoint(Vector3 target){

        float z = target.z - this.transform.position.z;
		float x = target.x - this.transform.position.x;
		float a = Mathf.Atan2(z, x) * (-180) / Mathf.PI;
		this.m_transform.Rotate (new Vector3 (0, a, 0));
        //StartCoroutine(setrotation(this.transform.eulerAngles.y, a, this.gameObject, target));
		moveTargetPoint = target;
		isPointed = true;

		
	}

    IEnumerator setrotation(float a, float b, GameObject x, Vector3 target, int times = 10)
    { 
        int i = 0;
        times = (int)Mathf.Abs(b - a) / 20+1;
        float angle = (b-a) / times;
        if ((b - a) < -180)
        {
            angle = (360-(a-b)) / times;
            while (i < times)
            {
                i++;
                Quaternion Q = Quaternion.Euler(0f, a + angle * i, 0f);
                x.transform.rotation = Q;
                yield return new WaitForSeconds(0.05f);
                
            }
        }
        else
        {
            while (i < times)
            {
                i++;
                Quaternion Q = Quaternion.Euler(0f, a + angle * i, 0f);
                x.transform.rotation = Q;
                yield return new WaitForSeconds(0.05f);
            }
        }
        moveTargetPoint = target;
        isPointed = true;

    }



//	void OnPostRender(){
//
//		GL.Begin(GL.LINES);
//		GL.Color(Color.red);
//		
//		GL.Vertex(new Vector3(0,0,0));
//		
//		GL.Vertex(new Vector3(100,100,100));
//		
//		GL.End();
//	}
}
