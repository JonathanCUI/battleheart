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
        Entity.playAnimation("zombie_bite");
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
        if (enemy.CurrentLifePoint < enemy.LifePoint)
        {
            Entity.transform.LookAt(enemy.getPosition());
            //治疗
        }
        else
        {
            changeToHuntingState(Entity);
        }
    }
    
}
