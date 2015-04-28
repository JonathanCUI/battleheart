using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 战斗常量设置
 * */
public class BattleConfig{

	/**
	 * type of gaming charactor 
	 **/
	public enum RobotType{
		HERO,
		BOSS,
		CREATURE
	}
	
	/**
	 *  type of robot action
	 **/
	public enum ActionType{
		NORMAL,
		RUN,
		ATTACK,
		DEFEND,
		DIE,
	}
	
	/**
	 * 攻击类型枚举
	 **/
	public enum AttackType{
		SHORT,//近战
		LONG,//远程
		SUPPORT,//补助
	}
	
	/**
	 * 技能使用策略类型
	 * */
	public enum PriorityStrategy{
		SHORT,//敌方单位的近战
		LONG,//敌方单位的远程
		CLOSTEST,//距离自身最近的敌对
		SELF_LIFE,//生命值不满的自身
		LEAST_LIFE,//生命值最少的己方
		SELF_EFFECT,//没有效果补助的自身
		NO_EFFECT,//没有效果补助的己方
	}

}
