using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 刺客攻击目标状态
 **/
public class Assassinator_AttackState : AttackState
{
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_WalkState());
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_WalkState());
    }
    public override void changeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_HuntingState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
        Entity.playAnimation("ghost_attack_with_ball");
        baseAttackingTarget(Entity, BattleConfig.AttackType.LONG);

    }
}
