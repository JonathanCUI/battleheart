using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * hero robot
 * */
public class HeroRobot : BaseRobot {

	// Use this for initialization
	void Start () {
		base.Start ();
		// set ID
		//SetID((int) RobotType.HERO);
		initState ();
	}

	void Update ()
	{	
		base.Update ();
		//调用正在使用的状态		
        //m_pStateMachine.SMUpdate();
	}

	protected virtual void initState(){
		
		//设置状态接口，并指向一个状态
		
		m_pStateMachine = new StateMachine<HeroRobot>(this);
		m_pStateMachine.SetCurrentState (new Hero_WalkState ());
	}

	public override void changeState(IState state){
		m_pStateMachine.ChangeState (state);
	}

	public override void changeToDeathState(){
		this.changeState (new DeathState());
	}
}
