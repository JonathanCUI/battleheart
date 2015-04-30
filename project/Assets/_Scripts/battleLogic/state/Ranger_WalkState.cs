using UnityEngine;
using System.Collections;

public class Ranger_WalkState : WalkState
{

	public Ranger_WalkState(){
		walk = "dragon_fly";
	}
	public override void ChangeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Ranger_IdleState());
    }

//    public override void Execute<T>(T Entity)
//    {
//        if (!Entity.userPointed())
//        {
//            ChangeState(Entity);
//        }
//        else
//        {
//            Entity.playAnimation("dragon_fly");
//        }
//    }
}
