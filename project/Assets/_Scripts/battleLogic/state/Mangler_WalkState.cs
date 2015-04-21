using UnityEngine;
using System.Collections;

public class Mangler_WalkState : State<Mangler> {
	
	public override void Enter (Mangler Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (Mangler Entity)
	{
		base.Execute (Entity);	
		Entity.playAnimation("walk");
	}
	
	public override void Exit (Mangler Entity)
	{
		base.Exit (Entity);
	}
}
