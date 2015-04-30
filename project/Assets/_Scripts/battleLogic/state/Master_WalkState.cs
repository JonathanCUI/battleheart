using UnityEngine;
using System.Collections;

public class Master_WalkState : WalkState {
    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Master_IdleState());
    }

    public override void Execute<T>(T Entity)
    {
        if (!Entity.userPointed())
        {
            ChangeState(Entity);
        }
        else
        {
            Entity.playAnimation("skeleton_walk");
        }
    }
}
