using UnityEngine;
using System.Collections;

public class Assassinator_WalkState : State<Assassinator> {

	public override void Enter (Assassinator Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (Assassinator Entity)
	{
		base.Execute (Entity);	
		Entity.playAnimation("walk");
	}
	
	public override void Exit (Assassinator Entity)
	{
		base.Exit (Entity);
	}
}
