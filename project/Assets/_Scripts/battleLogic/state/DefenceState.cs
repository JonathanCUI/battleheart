using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 受到攻击状态
 * */
public class DefenceState : IState {

	public virtual void Enter<T>(T Entity) where T : BaseRobot
	{
		//Entity.playAnimation("walk");
	}
	
	public virtual void Execute<T>(T Entity) where T : BaseRobot
	{
		ChangeToATKState (Entity);
	}
	
	public virtual void Exit<T>(T Entity) where T : BaseRobot
	{
		
	}

	public virtual void ChangeToATKState<T>(T Entity) where T : BaseRobot{
		//Entity.changeState (new AttackState());
	}
}
