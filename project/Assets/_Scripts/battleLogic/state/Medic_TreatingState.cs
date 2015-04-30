using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Medic_TreatingState : AttackState
{
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Medic_WalkState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
        Entity.playAnimation("zombie_bite");
    }

}
