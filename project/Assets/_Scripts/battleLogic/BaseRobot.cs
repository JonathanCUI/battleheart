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


    //转动次数
    int timeangle=5;

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

	public void setMoveTowardsPoint(Vector3 target){
        //this.gameObject.transform.LookAt(target);
        //moveTargetPoint = target;
        //isPointed = true;


        float z = target.z - this.transform.position.z;
        float x = target.x - this.transform.position.x;
        float a = Mathf.Atan2(z, x) * (-180) / 3.1415926f + 90;
        StartCoroutine(setrotation(this.transform.eulerAngles.y, a, this.gameObject, target));

		
	}

    IEnumerator setrotation(float a, float b, GameObject x, Vector3 target)
    { 
        int i = 0;
        int times = (int)Mathf.Abs(b - a) / timeangle + 1;
        float angle = (b-a) / times;
        if ((b - a) < -180)
        {
            angle = (360-(a-b)) / times;
            while (i < times)
            {
                i++;
                Quaternion Q = Quaternion.Euler(0f, a + angle * i, 0f);
                x.transform.rotation = Q;
                yield return new WaitForSeconds(Time.deltaTime);
                
            }
        }
        else
        {
            while (i < times)
            {
                i++;
                Quaternion Q = Quaternion.Euler(0f, a + angle * i, 0f);
                x.transform.rotation = Q;
                yield return new WaitForSeconds(Time.deltaTime);
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
