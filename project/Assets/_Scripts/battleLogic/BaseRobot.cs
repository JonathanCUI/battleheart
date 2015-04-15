using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * AI implementation with state design pattern
 **/
public class BaseRobot : MonoBehaviour {

	protected Vector3 m_targetPos;
	protected Transform m_transform;
	protected float m_speed = 500;

	protected bool isPointed=false;

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

	public int ID ()
	{
		return m_ID;
	}
	
	protected void SetID (int val)
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
		m_transform = this.transform;
		m_targetPos = m_transform.position;


	}
	
	// Update is called once per frame
	protected void Update () {
		m_pStateMachine.SMUpdate();
		updateMovement ();
	}

	/**
	 * update movement
	 * */
	void updateMovement(){
		if (Input.GetMouseButtonDown (0)) {
			Vector3 ms = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (ms);
			RaycastHit hitinfo;
			LayerMask mask = new LayerMask ();
			mask.value = (int)Mathf.Pow(2.0f,(float)LayerMask.NameToLayer("plane"));
			bool iscast = Physics.Raycast (ray,out hitinfo,1000,mask);
			if (iscast) {
				m_targetPos = hitinfo.point;
				isPointed=true;
			}

		}
		if (isPointed){
			Vector3 pos = Vector3.MoveTowards (this.m_transform.position,m_targetPos,m_speed * Time.deltaTime);
			m_transform.Translate(pos, Space.World);
			m_transform.position = pos;
			if(m_transform.position==m_targetPos){
				isPointed=false;
			}else{
			}

	    }

	}

	public void playAnimation(string name){
		
		animation.Play (name);
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
