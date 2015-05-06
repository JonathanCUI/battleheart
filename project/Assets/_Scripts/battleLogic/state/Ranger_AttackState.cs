using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 远程攻击目标状态
 **/
public class Ranger_AttackState : AttackState
{
    public Ranger_AttackState(BaseRobot t)
        : base(t)
    {
		//enemy = t;
	}

    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Ranger_WalkState());
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Ranger_IdleState());
    }

    public override void changeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Ranger_HuntingState());
    }
    public override void AttackingTarget<T>(T Entity)
    {
        Entity.animation["dragon_bite"].speed = Entity.animation["dragon_bite"].length;
        if (Entity.animation.isPlaying && !Entity.animation.IsPlaying("dragon_bite"))
        {
            Entity.playAnimation("dragon_bite");
        }

        if (!Entity.animation.isPlaying)
        {
            Entity.playAnimation("dragon_bite");
            ishit = false;
        }
        baseAttackingTarget(Entity);
    }

    public override void changeToDeathState<T>(T Entity)
    {
        Entity.changeState(new Ranger_DeathState());
    }

}
