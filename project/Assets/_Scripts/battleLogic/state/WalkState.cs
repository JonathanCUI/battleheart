using UnityEngine;
using System.Collections;
/**
 * Desmond
 * 单纯步行 base
 * */
public class WalkState :IState {
	
	public virtual void Enter<T> (T Entity) where T:BaseRobot
	{
		//Entity.playAnimation("walk");
	}
	
	public virtual void Execute<T> (T Entity) where T:BaseRobot
	{
		if (!Entity.userPointed ()) {
			ChangeState(Entity);
		} else {
			Entity.playAnimation ("walk");
		}
	}
	
	public virtual void Exit<T> (T Entity) where T:BaseRobot
	{
		
	}

	public virtual void ChangeState<T>(T Entity) where T:BaseRobot
	{
		Entity.changeState (new IdleState ());
	}
}
