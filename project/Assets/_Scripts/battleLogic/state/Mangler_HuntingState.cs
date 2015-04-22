using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 肉盾搜寻目标状态
 **/
public class Mangler_HuntingState : State<Mangler> {
	
	public override void Enter (Mangler Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (Mangler Entity)
	{
		base.Execute (Entity);	
		Dictionary<int,BaseRobot> opps = Entity.GameTargets;
		if (opps != null && opps.Count!=0) {
			Entity.playAnimation ("walk");
			float relativeDistance=100000f,minDistance = 100000f;
			int first_id=-1,second_id=-1;
			foreach (KeyValuePair<int,BaseRobot> kv in opps) {
				float dis = Vector3.Distance (Entity.getPosition (), kv.Value.getPosition ());
				if (kv.Value.AttackType == BattleConfig.AttackType.SHORT) {//判断近战 选取距离最近的目标
					if(dis<relativeDistance){
						first_id=kv.Key;
						relativeDistance=dis;
					}
				}
			    
				if (dis < minDistance) {//选取距离最近的目标
					second_id = kv.Key;
					minDistance = dis;
				}
			}
			Entity.setMoveTowardsPoint(opps[first_id!=-1?first_id:second_id].getPosition());
		} else {
			Entity.playAnimation("idle");
		}
		
	}
	
	public override void Exit (Mangler Entity)
	{
		base.Exit (Entity);
	}
}
