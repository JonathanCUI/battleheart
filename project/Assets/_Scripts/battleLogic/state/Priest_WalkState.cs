using UnityEngine;
using System.Collections;

public class Priest_WalkState : WalkState
{

	public Priest_WalkState(){
		walk = "mummy_walk";
	}
	public override void ChangeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Priest_IdleState());
    }

    public override void changeToDeathState<T>(T Entity)
    {
        Entity.changeState(new Priest_DeathState());
    }

//    public override void Execute<T>(T Entity)
//    {
//        if (!Entity.userPointed())
//        {
//            ChangeState(Entity);
//        }
//        else
//        {
//            Entity.playAnimation("mummy_walk");
//        }
//    }
}
