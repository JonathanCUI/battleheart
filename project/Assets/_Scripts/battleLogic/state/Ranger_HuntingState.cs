using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 远程物攻搜寻目标状态
 **/
public class Ranger_HuntingState : HuntingState
{

    //状态变换为walk
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Ranger_WalkState());
    }

	//状态变换为idle
	public override void changeToIdleState<T> (T Entity) 
	{
		Entity.changeState(new Ranger_IdleState());
	}
	
	//状态变换为attack
	public override void changeToATKState<T> (T Entity)
	{
		Entity.changeState(new Ranger_AttackState());
	}
	
	//寻找对手AI策略
	public override void huntingStrategy<T> (T Entity)
	{
		baseHuntingStrategy (Entity, BattleConfig.AttackType.LONG);
	}

}
