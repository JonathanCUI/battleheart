using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 战斗任务属性表
 * */
public class Ttxt_battle_character_info : TxtData {
	
	public override void dataFinish(string[] data){

		Ttxt_battle_character_info info = new Ttxt_battle_character_info ();
		info._Id = System.Convert.ToInt32( data [0]);
		info.Name = data [1];
		info.Type = System.Convert.ToInt32(data [2]);
		info.LifePoint = System.Convert.ToInt32(data[3]);
		info.Defence = System.Convert.ToInt32(data[4]);
		info.Attack = System.Convert.ToInt32(data[5]);
		info.HitOdds = System.Convert.ToInt32(data[6]);
		info.Escape = System.Convert.ToInt32(data[7]);
		info.Attribute = System.Convert.ToInt32(data[8]);
		info.AttrEffect = System.Convert.ToInt32(data[9]);
		info.Power = System.Convert.ToInt32(data[10]);
		info.AttackDistance = System.Convert.ToInt32(data[11]);
		info.FirstPriority = System.Convert.ToInt32(data[12]);
		info.SecondPriority = System.Convert.ToInt32(data[13]);
		if(Ttxt_battle_character_info.DATA==null)
			Ttxt_battle_character_info.DATA = new Dictionary<int, Ttxt_battle_character_info>();
		Ttxt_battle_character_info.DATA.Add (info._Id, info);
	}
	
	public override void clearAll(){
		if (Ttxt_battle_character_info.DATA != null)
			Ttxt_battle_character_info.DATA.Clear ();
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
