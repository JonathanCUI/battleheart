using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
 * Desmond
 * 搜寻目标状态 base
 * */
public class HuntingState :IState {

	public virtual void Enter<T> (T Entity) where T:BaseRobot
	{
		//Entity.playAnimation("walk");
	}
	
	public virtual void Execute<T> (T Entity) where T:BaseRobot
	{
		if (Entity.userPointed ()) {//玩家指定位置
			changeToWalkState(Entity);
			return ;
		}
		if (Entity.isMeetingEnemy ()) {
			changeToATKState();
			return;
		}
		huntingStrategy (Entity);
	}
	
	public virtual void Exit<T> (T Entity) where T:BaseRobot
	{
		
	}

	//状态变换为walk
	public virtual void changeToWalkState<T> (T Entity) where T:BaseRobot
	{
		Entity.changeState(new WalkState());
	}

	//状态变换为idle
	public virtual void changeToIdleState<T> (T Entity) where T:BaseRobot
	{
		Entity.changeState(new IdleState());
	}

	//状态变换为attack
	public virtual void changeToATKState<T> (T Entity) where T:BaseRobot
	{
		Entity.changeState(new AttackState());
	}

	//寻找对手AI策略
	public virtual void huntingStrategy<T> (T Entity) where T:BaseRobot
	{
	}

	public virtual void baseHuntingStrategy<T>(T Entity,BattleConfig.AttackType atkType) where T:BaseRobot
	{
		Dictionary<int,BaseRobot> opps = Entity.GameTargets;
		if (opps != null && opps.Count!=0) {
			Entity.playAnimation ("walk");
			float relativeDistance=100000f,minDistance = 100000f;
			int first_id=-1,second_id=-1;
			foreach (KeyValuePair<int,BaseRobot> kv in opps) {
				float dis = Vector3.Distance (Entity.getPosition (), kv.Value.getPosition ());
				if (kv.Value.AttackType == atkType) {//判断近战 选取距离最近的目标
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
			BaseRobot targetEnmy = opps[first_id != -1 ? first_id : second_id];
			float disx = Vector3.Distance(Entity.getPosition(), targetEnmy.getPosition());
			if (disx > Entity.AttackDistance)
			{
				Entity.setAITowardsPoint(targetEnmy.getPosition());
				changeToWalkState(Entity);
			}
			else
			{
				Entity.setAITowardsPoint(Entity.getPosition());
				changeToATKState(Entity);
			}
		} else {
			changeToIdleState(Entity);
		}
	}
}
