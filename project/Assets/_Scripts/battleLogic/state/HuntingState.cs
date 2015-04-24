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
            Debug.Log(123);
			changeToWalkState(Entity);
			return ;
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

	//寻找对手AI策略
	public virtual void huntingStrategy<T> (T Entity) where T:BaseRobot
	{
	}
}
