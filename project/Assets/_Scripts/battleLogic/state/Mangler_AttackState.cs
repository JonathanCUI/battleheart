using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Desmond
 * 肉盾攻击目标状态
 **/
public class Mangler_AttackState : AttackState
{
    public Mangler_AttackState(BaseRobot t)
        : base(t)
    {
		//enemy = t;
	}

    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Mangler_WalkState());
    }

    public override void changeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Mangler_HuntingState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
        if (!Entity.animation.isPlaying||!Entity.animation.IsPlaying("punch"))
        {
            ishit = false;
            Entity.playAnimation("punch");
        }
        baseAttackingTarget(Entity);
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Mangler_IdleState());
    }

    public override void changeToDeathState<T>(T Entity)
    {
        Entity.changeState(new Mangler_DeathState());
    }
}
