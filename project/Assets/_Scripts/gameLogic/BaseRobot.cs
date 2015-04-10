using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * AI implementation with state design pattern
 **/
public class BaseRobot : MonoBehaviour {

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
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
