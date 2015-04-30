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
    //寻找对手AI策略
    public override void huntingStrategy<T>(T Entity)
    {	
		Dictionary<int,BaseRobot> opps = Entity.GameTargets;
		if (opps != null && opps.Count!=0) {

            Entity.changeState(new Medic_TreatingState());
			//Entity.playAnimation ("punch");
            //float relativeDistance=100000f,minDistance = 100000f;
            //int first_id=-1,second_id=-1;
            //foreach (KeyValuePair<int,BaseRobot> kv in opps) {
            //    float dis = Vector3.Distance (Entity.getPosition (), kv.Value.getPosition ());
            //    if (kv.Value.AttackType == BattleConfig.AttackType.SHORT) {//判断近战 选取距离最近的目标
            //        if(dis<relativeDistance){
            //            first_id=kv.Key;
            //            relativeDistance=dis;
            //        }
            //    }
			    
            //    if (dis < minDistance) {//选取距离最近的目标
            //        second_id = kv.Key;
            //        minDistance = dis;
            //    }
            //}
			//Entity.setMoveTowardsPoint(Entity.getPosition());
		} else {
            Entity.playAnimation("zombie_idle2");
		}
		
	}

}
