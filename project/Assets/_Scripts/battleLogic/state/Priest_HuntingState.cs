using UnityEngine;
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
    //寻找对手AI策略
    public override void huntingStrategy<T>(T Entity)
    {
		
        Entity.changeState(new Priest_AttackState());
		
	}

}
