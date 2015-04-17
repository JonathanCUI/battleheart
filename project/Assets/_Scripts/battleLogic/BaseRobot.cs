using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * AI implementation with state design pattern
 **/
public class BaseRobot : MonoBehaviour {

	protected Transform m_transform;
	protected float m_speed = 500;

	protected bool isPointed=false;
	protected Vector3 moveTargetPoint;
	//人物选中光圈
	protected bool selectedHalo=false;

	//指向一个状态实例的指针
	protected StateMachine<HeroRobot> m_pStateMachine;

	/**
	 * type of gaming charactor 
	 **/
	public enum RobotType{
		HERO,
		BOSS,
		CREATURE
	}

	/**
	 *  type of robot action
	 **/
	public enum ActionType{
		NORMAL,
		RUN,
		ATTACK,
		DEFEND,
		DIE,
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
		moveTargetPoint = m_transform.position;

	}
	
	// Update is called once per frame
	protected void Update () {
		m_pStateMachine.SMUpdate();
//		updateEffect ();
		updateMovement ();
//		isOjbSelected ();
	}


	protected void updateEffect(){

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

	public void setMoveTowardsPoint(Vector3 point){
		moveTargetPoint = point;
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
