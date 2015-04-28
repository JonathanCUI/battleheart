using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 战斗任务属性表
 * */
public class Ttxt_battle_character_info : TxtData {

#if UNITY_EDITOR
    string filepath = Application.dataPath + "/StreamingAssets";

#elif UNITY_IPHONE
	  string filepath = Application.dataPath +"/Raw";
 
#elif UNITY_ANDROID
	  string filepath = "jar:file://" + Application.dataPath + "!/assets/";
#endif

    ArrayList herodata;

	public override void dataFinish(string x){
        //Debug.Log(Application.streamingAssetsPath);
        //WWW www = new WWW(Application.streamingAssetsPath + "/datahero");
        //while (!www.isDone) { }
        //herodata = Readtxt.loadtxt(www.text);
        herodata = Readtxt.LoadFile(filepath, x);

        Debug.Log(herodata.Count);
        
        string[] heroID = Readtxt.loaddata(herodata, "ID");
        string[] heroname = Readtxt.loaddata(herodata, "name");
        string[] herotype = Readtxt.loaddata(herodata, "type");
        string[] herolifePoint = Readtxt.loaddata(herodata, "lifePoint");
        string[] herodefence = Readtxt.loaddata(herodata, "defence");
        string[] heroattack = Readtxt.loaddata(herodata, "attack");
        string[] herohitOdds = Readtxt.loaddata(herodata, "hitOdds");
        string[] heroescape = Readtxt.loaddata(herodata, "escape");
        string[] heroattribute = Readtxt.loaddata(herodata, "attribute");
        string[] heroattrEffect = Readtxt.loaddata(herodata, "attrEffect");
        string[] heropower = Readtxt.loaddata(herodata, "power");
        string[] heroattackDistance = Readtxt.loaddata(herodata, "attackDistance");
        string[] herofirstPriority = Readtxt.loaddata(herodata, "firstPriority");
        string[] herosecondPriority = Readtxt.loaddata(herodata, "secondPriority");
        for (int i = 0; i <herodata.Count-2; i++)
        {
            Ttxt_battle_character_info hero = new Ttxt_battle_character_info();
            hero._Id = System.Convert.ToInt32 (heroID[i]);
            hero.Name = heroname[i];
            hero.Type = System.Convert.ToInt32(herotype[i]);
            hero.LifePoint = System.Convert.ToInt32(herolifePoint[i]);
            hero.Defence = System.Convert.ToInt32(herodefence[i]);
            hero.Attack = System.Convert.ToInt32(heroattack[i]);
            hero.HitOdds = System.Convert.ToInt32(herohitOdds[i]);
            hero.Escape = System.Convert.ToInt32(heroescape[i]);
            hero.Attribute = System.Convert.ToInt32(heroattribute[i]);
            hero.AttrEffect = System.Convert.ToInt32(heroattrEffect[i]);
            hero.Power = System.Convert.ToInt32(heropower[i]);
            hero.AttackDistance = System.Convert.ToInt32(heroattackDistance[i]);
            hero.FirstPriority = System.Convert.ToInt32(herofirstPriority[i]);
            hero.SecondPriority = System.Convert.ToInt32(herosecondPriority[i]);

            Ttxt_battle_character_info.DATA = new Dictionary<int, Ttxt_battle_character_info>();
            Ttxt_battle_character_info.DATA.Add(hero._Id, hero);
        }
	}

    void readherodata()
    { 
    
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
