using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 肉盾搜寻目标状态
 **/
public class Medic_HuntingState : HuntingState
{

    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Medic_WalkState());
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Medic_IdleState());
    }

    public override void changeToATKState<T>(T Entity)
    {
        Entity.changeState(new Medic_AttackState());
    }

    //寻找对手AI策略
    public override void huntingStrategy<T>(T Entity)
    {	
		Dictionary<int,BaseRobot> opps = Entity.GameTargets;
		if (opps != null && opps.Count!=0) {

            changeToATKState(Entity);
		} else {
            changeToIdleState(Entity);
		}
	}

}
