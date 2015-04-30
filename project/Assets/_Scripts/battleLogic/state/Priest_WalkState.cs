using UnityEngine;
using System.Collections;

public class Priest_WalkState : WalkState
{
    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Priest_IdleState());
    }

    public override void Execute<T>(T Entity)
    {
        if (!Entity.userPointed())
        {
            ChangeState(Entity);
        }
        else
        {
            Entity.playAnimation("mummy_walk");
        }
    }
}
