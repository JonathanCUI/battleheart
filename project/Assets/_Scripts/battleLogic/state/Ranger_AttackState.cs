using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 远程攻击目标状态
 **/
public class Ranger_AttackState : AttackState
{
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Ranger_WalkState());
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Ranger_IdleState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
       
        Entity.playAnimation("dragon_bite");
        baseAttackingTarget(Entity, BattleConfig.AttackType.LONG);
    }
}
