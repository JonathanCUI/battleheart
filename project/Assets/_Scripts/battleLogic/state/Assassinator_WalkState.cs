using UnityEngine;
using System.Collections;

public class Assassinator_WalkState : WalkState {
    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_IdleState());
    }

    public override void Execute<T>(T Entity)
    {
        if (!Entity.userPointed())
        {
            ChangeState(Entity);
        }
        else
        {
            Entity.playAnimation("ghost_idle_side_to_side");
        }
    }
}
