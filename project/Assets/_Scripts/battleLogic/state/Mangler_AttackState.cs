using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Desmond
 * 肉盾攻击目标状态
 **/
public class Mangler_AttackState : AttackState
{
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Mangler_WalkState());
    }


    public override void AttackingTarget<T>(T Entity)
    {
        Debug.Log("AttackingTarget");
        Entity.playAnimation("punch");
        baseAttackingTarget(Entity, BattleConfig.AttackType.SHORT);
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Mangler_IdleState());
    } 

}
