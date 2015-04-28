using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 本地数据表抽象管理抽象类
 * */
public class TxtClassFactory {

	public virtual void loadAll(){

	}

	public virtual TxtData getInstance(string classKey){
		return null;
	}
}
