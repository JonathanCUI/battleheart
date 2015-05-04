using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 肉盾闲置状态
 **/
public class Mangler_IdleState : IdleState {
	
	public override void ChangeToHuntingState<T> (T Entity)
	{
		Entity.changeState (new Mangler_HuntingState ());
	}
}
