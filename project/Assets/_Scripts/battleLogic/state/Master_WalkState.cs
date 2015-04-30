using UnityEngine;
using System.Collections;

public class Master_WalkState : WalkState {
	
	public Master_WalkState(){

		walk="skeleton_walk";
	}

	public override void ChangeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Master_IdleState());
    }

//    public override void Execute<T>(T Entity)
//    {
//        if (!Entity.userPointed())
//		{skeleton_walk
//            ChangeState(Entity);
//        }
//        else
//        {
//            Entity.playAnimation("skeleton_walk");
//        }
//    }
}
