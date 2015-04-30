using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Priest_AttackState : AttackState
{
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Priest_WalkState());
    }


    public override void AttackingTarget<T>(T Entity)
    {
        Entity.playAnimation("mummy_walk");
    }
}
