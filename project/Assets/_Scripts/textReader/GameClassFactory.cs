using UnityEngine;
using System.Collections;
/**
 * Desmond
 * 本地数据表抽象管理实现类
 * */
public class GameClassFactory : TxtClassFactory {
	
	static public void loadTxt(TxtClassFactory txtClass,string classKey,string path){
		Readtxt.load (txtClass,classKey,path);
	}

	public override void loadAll(){
		GameClassFactory.loadTxt (this, "battle_character_info", "");
	}
	
	public override TxtData getInstance(string classKey){
		if(classKey == "battle_character_info" )
		{
			return new Ttxt_battle_character_info();
		}

		return null;
	}
}
