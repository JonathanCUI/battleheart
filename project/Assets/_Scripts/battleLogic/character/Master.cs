using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 远程法师
 * */
public class Master : HeroRobot {

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
		
		m_pStateMachine = new StateMachine<Master>(this);
		m_pStateMachine.SetCurrentState(new Master_WalkState());
	}


	public override void changeToDeathState(){
		this.changeState (new Master_DeathState());
	}

	public override int getAtkForce()
	{
		return this.attrEffect;
	}
}
