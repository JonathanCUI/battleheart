using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Master_AttackState : AttackState
{
    public Master_AttackState(BaseRobot t)
        : base(t)
    {
		//enemy = t;
	}

    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Master_WalkState());
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Master_IdleState());
    }

    public override void changeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Master_HuntingState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
        Entity.animation["skeleton_attack"].speed = Entity.animation["skeleton_attack"].length;
        if (Entity.animation.isPlaying && !Entity.animation.IsPlaying("skeleton_attack"))
        {
            Entity.playAnimation("skeleton_attack");
        }

        if (!Entity.animation.isPlaying)
        {
            Entity.playAnimation("skeleton_attack");
            ishit = false;
        }
        baseAttackingTarget(Entity);
    }

    public override void changeToDeathState<T>(T Entity)
    {
        Entity.changeState(new Master_DeathState());
    }
    //获得法师的属性攻击
    //protected override int getDamage(BaseRobot Entity)
    //{
    //    return Entity.AttrEffect;
    //}

}