using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 肉盾单纯步行
 * */
public class Mangler_WalkState : WalkState {
	
	public override void ChangeToIdleState<T> (T Entity)
	{
		Entity.changeState (new Mangler_IdleState ());

	}


}
