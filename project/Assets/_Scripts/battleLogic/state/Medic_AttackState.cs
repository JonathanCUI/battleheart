using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Desmond
 * 生命补助治疗目标状态
 **/

public class Medic_AttackState : AttackState
{
    public Medic_AttackState(BaseRobot t)
        : base(t)
    {
		//enemy = t;
	}

    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Medic_WalkState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
        Entity.animation["zombie_bite"].speed = Entity.animation["zombie_bite"].length;
        if (Entity.animation.isPlaying && !Entity.animation.IsPlaying("zombie_bite"))
        {
            Entity.playAnimation("zombie_bite");
        }

        if (!Entity.animation.isPlaying)
        {
            Entity.playAnimation("zombie_bite");
            ishit = false;
        }
        baseAttackingTarget(Entity);
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Medic_HuntingState());
    }

    public override void changeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Medic_HuntingState());
    }

    public override void baseAttackingTarget<T>(T Entity)
    {
        if (enemy.CurrentLifePoint < enemy.LifePoint&&!ishit)
        {
            Entity.transform.LookAt(enemy.getPosition());
            //治疗
            enemy.CurrentLifePoint += (int)(enemy.LifePoint * 0.08f);
            enemy.CurrentLifePoint = enemy.CurrentLifePoint > enemy.LifePoint ? enemy.LifePoint : enemy.CurrentLifePoint;
        }
        if (enemy.CurrentLifePoint == enemy.LifePoint)
        {
            changeToHuntingState(Entity);
        }
    }
    public override void changeToDeathState<T>(T Entity)
    {
        Entity.changeState(new Medic_DeathState());
    }
    
}
