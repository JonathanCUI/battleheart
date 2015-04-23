using UnityEngine;
using System.Collections;


/**
 * Desmond
 * 肉盾搜寻目标状态
 **/
public class IdleState:IState {

	public virtual void Enter<T> (T Entity) where T:BaseRobot
	{

	}
	
	public virtual void Execute<T> (T Entity) where T:BaseRobot
	{
		//进入搜寻对手转态
		ChangeState (Entity);
	}
	
	public virtual void Exit<T> (T Entity) where T:BaseRobot
	{
		
	}

	public virtual void ChangeState<T>(T Entity) where T:BaseRobot
	{
		Entity.changeState (new HuntingState ());
	}
}
