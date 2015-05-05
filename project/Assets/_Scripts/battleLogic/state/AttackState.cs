﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 攻击/治疗目标状态 base
 * */

public class AttackState : IState
{

	protected BaseRobot enemy;
    protected bool ishit=true;
	public AttackState(BaseRobot t){
		enemy = t;
	}

    public virtual void Enter<T>(T Entity) where T : BaseRobot
    {
        //Entity.playAnimation("walk");
    }

    public virtual void Execute<T>(T Entity) where T : BaseRobot
    {
        if (Entity.userPointed())
        {//玩家指定位置
            changeToWalkState(Entity);
            return;
        }
        if (Entity.CurrentLifePoint <= 0)
        {
            changeToDeathState(Entity);
        }
        AttackingTarget(Entity);
    }

    public virtual void Exit<T>(T Entity) where T : BaseRobot
    {

    }


    public virtual void changeToDeathState<T>(T Entity)where T : BaseRobot
    {
        Debug.Log(Entity);
    }


    //状态变换为walk
    public virtual void changeToWalkState<T>(T Entity) where T : BaseRobot
    {
        Entity.changeState(new WalkState());
    }

    public virtual void changeToHuntingState<T>(T Entity) where T : BaseRobot
    {
        Entity.changeState(new HuntingState());
    }

    //状态变换为idle
    public virtual void changeToIdleState<T>(T Entity) where T : BaseRobot
    {
        Entity.changeState(new IdleState());
    }

    //攻击、治疗目标
    public virtual void AttackingTarget<T>(T Entity) where T : BaseRobot
    {
    }

    public virtual void baseAttackingTarget<T>(T Entity) where T : BaseRobot
    {
        Entity.transform.LookAt(enemy.getPosition());
        float disx = Vector3.Distance(Entity.getPosition(), enemy.getPosition());

        if (disx > Entity.AttackDistance)
        {
            changeToHuntingState(Entity);
        }
        
        if (enemy.CurrentLifePoint > 0&&!ishit)
        {
            //造成伤害
            Debug.Log(enemy.CurrentLifePoint);




            ishit = true;
        }
        else
        {
            //changeToHuntingState(Entity);
        }


    }


}
