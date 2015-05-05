using UnityEngine;
using System.Collections;
/**
 * Desmond
 * 单纯步行 base
 * */
public class WalkState :IState {

	protected string walk="walk";

	public virtual void Enter<T> (T Entity) where T:BaseRobot
	{
		//Entity.playAnimation("walk");
	}
	
	public virtual void Execute<T> (T Entity) where T:BaseRobot
    {
        if (Entity.CurrentLifePoint <= 0)
        {
            changeToDeathState(Entity);
        }
        if (!Entity.userPointed())
        {
			ChangeToIdleState(Entity);
		}
			Entity.playAnimation (walk);
	}
	
	public virtual void Exit<T> (T Entity) where T:BaseRobot
	{
		
	}

	public virtual void ChangeToIdleState<T>(T Entity) where T:BaseRobot
	{
		Entity.changeState (new IdleState ());
	}

    public virtual void changeToDeathState<T>(T Entity) where T : BaseRobot
    {
        Debug.Log(Entity);
    }
}
