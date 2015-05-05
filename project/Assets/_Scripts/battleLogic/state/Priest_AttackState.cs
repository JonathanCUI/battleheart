using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Desmond
 * 效果补助加BUFF目标状态
 **/
public class Priest_AttackState : AttackState
{
    public Priest_AttackState(BaseRobot t)
        : base(t)
    {
		//enemy = t;
	}

    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Priest_WalkState());
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Priest_IdleState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
        Entity.animation["mummy_bite"].speed =Entity.animation["mummy_bite"].length;
        if (Entity.animation.isPlaying && !Entity.animation.IsPlaying("mummy_bite"))
        {
            Entity.playAnimation("mummy_bite");
        }

        if (!Entity.animation.isPlaying)
        {
            Entity.playAnimation("mummy_bite");
            ishit = false;
        }
        baseAttackingTarget(Entity);
    }

    public override void changeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Priest_HuntingState());
    }
    public override void baseAttackingTarget<T>(T Entity)
    {
        
        Entity.transform.LookAt(enemy.getPosition());
        //加状态

        changeToHuntingState(Entity);

    }

    public override void changeToDeathState<T>(T Entity)
    {
        Entity.changeState(new Priest_DeathState());
    }
}
