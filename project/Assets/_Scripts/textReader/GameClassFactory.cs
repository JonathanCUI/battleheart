using UnityEngine;
using System.Collections;
/**
 * Desmond
 * */
public class GameClassFactory : TxtClassFactory {

	protected override void loadAll(){

	}
	
	public override TxtData getInstance(string classKey){
		if(classKey == "houses_detail_info" )
		{
			return new Ttxt_houses_detail_info();
		}

		return null;
	}
}
