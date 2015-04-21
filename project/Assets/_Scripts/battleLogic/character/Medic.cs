using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 生命补助
 * */
public class Medic : HeroRobot {

	// Use this for initialization
	void Start () {
		base.Start ();
		initState ();
	}
	
	void Update ()
	{	
		base.Update ();
		//调用正在使用的状态		
		//m_pStateMachine.SMUpdate();
	}

	
	protected override void initState(){
		
		//设置状态接口，并指向一个状态
		
		m_pStateMachine = new StateMachine<Medic>(this);
		m_pStateMachine.SetCurrentState(new Medic_WalkState());
	}
}
