using UnityEngine;
using System.Collections;

public class Medic_WalkState : WalkState {
	
	public Medic_WalkState(){
		walk="zombie_walk";
	}
	public override void ChangeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Medic_IdleState());
    }
//    public override void Execute<T>(T Entity)
//    {
//        if (!Entity.userPointed())
//        {
//            ChangeState(Entity);
//        }
//        else
//        {
//            Entity.playAnimation("zombie_walk");
//        }
//    }
}
