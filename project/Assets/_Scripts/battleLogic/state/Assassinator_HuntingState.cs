﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 肉盾搜寻目标状态
 **/
public class Assassinator_HuntingState : HuntingState
{

    //状态变换为walk
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_WalkState());
    }


	//状态变换为idle
    public override void changeToIdleState<T>(T Entity)
	{
		Entity.changeState(new Assassinator_IdleState());
	}
	
	//状态变换为attack
    public override void changeToATKState<T>(T Entity,T enemy)
	{
		Entity.changeState(new Assassinator_AttackState(enemy));
	}
	
	//寻找对手AI策略
    public override void huntingStrategy<T>(T Entity)
	{
		baseHuntingStrategy (Entity, BattleConfig.AttackType.LONG);
	}

}
