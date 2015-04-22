using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 肉盾单纯步行
 * */
public class Mangler_WalkState : State<Mangler> {
	
	public override void Enter (Mangler Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (Mangler Entity)
	{
		base.Execute (Entity);	
		if (Entity.pointFound ()) {
			Entity.changeState(new Mangler_IdleState());
		} else {
			Entity.playAnimation ("walk");
		}

	}
	
	public override void Exit (Mangler Entity)
	{
		base.Exit (Entity);
	}
}
