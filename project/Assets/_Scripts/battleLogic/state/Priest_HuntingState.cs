﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 肉盾搜寻目标状态
 **/
public class Priest_HuntingState : HuntingState
{

    //状态变换为walk
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Priest_WalkState());
    }

	//状态变换为idle
	public override void changeToIdleState<T> (T Entity) 
	{
		Entity.changeState(new Priest_IdleState());
	}
	
	//状态变换为attack
	public override void changeToATKState<T> (T Entity)
	{
		Entity.changeState(new Priest_AttackState());
	}
	
	//寻找对手AI策略
	public override void huntingStrategy<T> (T Entity)
	{
        Dictionary<int, BaseRobot> opps = Entity.GameTargets;
        if (opps != null && opps.Count != 0)
        {

            changeToATKState(Entity);
        }
        else
        {
            changeToIdleState(Entity);
        }
	}

}