using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 刺客攻击目标状态
 **/
public class Assassinator_AttackState : AttackState
{
	public Assassinator_AttackState(BaseRobot t):base(t)
    {
		//enemy = t;
	}
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
        if (Entity.animation.isPlaying)
        {
            Debug.Log(Entity);
            Entity.playAnimation("ghost_attack_with_ball");
        }
        baseAttackingTarget(Entity);
    }

    public override void changeToDeathState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_DeathState());
    }
}
