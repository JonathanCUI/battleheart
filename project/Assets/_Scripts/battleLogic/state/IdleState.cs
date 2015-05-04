using UnityEngine;
using System.Collections;


/**
 * Desmond
 * 闲置状态 base
 **/
public class IdleState:IState {

	public virtual void Enter<T> (T Entity) where T:BaseRobot
	{

	}
	
	public virtual void Execute<T> (T Entity) where T:BaseRobot
	{
        //进入搜寻对手转态
		ChangeToHuntingState (Entity);
	}
	
	public virtual void Exit<T> (T Entity) where T:BaseRobot
	{
		
	}

	public virtual void ChangeToHuntingState<T>(T Entity) where T:BaseRobot
	{
		Entity.changeState (new HuntingState ());
	}
}
