using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 战斗任务属性表
 * */
public class Ttxt_battle_character_info : TxtData {
	
	public override void dataFinish(){
		
	}
	
	public override void clearAll(){
		
	}
	
	static public Dictionary<int,Ttxt_battle_character_info> DATA;
	
	int id;
	string name; //名称 
	int type;    //类型 
	int lifePoint;//生命 
	int defence; //防御 
	int attack;  //攻击 
	int hitOdds; //命中
	int escape;  //闪躲 
	int attribute;//属性 
	int attrEffect;//属性攻击 
	int power;     //战斗力
	int attackDistance;//攻击距离
	int allies;//同盟 0;1
	int firstPriority;//技能释放第一选择
	int secondPriority;//技能释放第二选择
	
	public int _Id{
		get 
		{ 
			return id; 
		}
		set 
		{
			id = value; 
		}
	}
	
	public string Name{
		get 
		{ 
			return name; 
		}
		set 
		{
			name = value; 
		}
		
	}
	
	public int Type{
		get 
		{ 
			return type; 
		}
		set 
		{
			type = value; 
		}
	}
	
	public int LifePoint{
		get 
		{ 
			return lifePoint; 
		}
		set 
		{
			lifePoint = value; 
		}
	}
	
	public int Defence{
		get 
		{ 
			return defence; 
		}
		set 
		{
			defence = value; 
		}
	}
	
	public int Attack{
		get 
		{ 
			return attack; 
		}
		set 
		{
			attack = value; 
		}
	}
	
	public int HitOdds{
		get 
		{ 
			return hitOdds; 
		}
		set 
		{
			hitOdds = value; 
		}
	}
	
	public int Escape{
		get 
		{ 
			return escape; 
		}
		set 
		{
			escape = value; 
		}
	}
	
	public int Attribute{
		get 
		{ 
			return attribute; 
		}
		set 
		{
			attribute = value; 
		}
	}
	
	public int AttrEffect{
		get 
		{ 
			return attrEffect; 
		}
		set 
		{
			attrEffect = value; 
		}
	}
	
	public int Power{
		get 
		{ 
			return power; 
		}
		set 
		{
			power = value; 
		}
	}
	
	public int AttackDistance{
		get 
		{ 
			return attackDistance; 
		}
		set 
		{
			attackDistance = value; 
		}
	}
	
	public int Allies 
	{
		get 
		{ 
			return allies; 
		}
		set 
		{
			allies = value; 
		}
	}
	public int FirstPriority 
	{
		get 
		{ 
			return firstPriority; 
		}
		set 
		{
			firstPriority = value; 
		}
	}
	public int SecondPriority 
	{
		get 
		{ 
			return secondPriority; 
		}
		set 
		{
			secondPriority = value; 
		}
	}
	
}
