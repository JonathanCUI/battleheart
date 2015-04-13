using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * hero robot
 * */
public class HeroRobot : BaseRobot {

	//指向一个状态实例的指针
	StateMachine<HeroRobot> m_pStateMachine;

	// Use this for initialization
	void Start () {
		// set ID
		SetID((int) RobotType.HERO);
		
		//设置状态接口，并指向一个状态
		m_pStateMachine = new StateMachine<HeroRobot>(this);
		m_pStateMachine.SetCurrentState(Hero_GlobalState.Instance());
	}

	void Update ()
	{	
		//调用正在使用的状态		
		m_pStateMachine.SMUpdate();
	}
	
	public StateMachine<HeroRobot> GetFSM ()
	{
		//返回状态管理机
		return m_pStateMachine;
	}
}
