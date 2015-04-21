using UnityEngine;
using System.Collections;

public class Master_WalkState : State<Master> {
	
	public override void Enter (Master Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (Master Entity)
	{
		base.Execute (Entity);	
		Entity.playAnimation("walk");
	}
	
	public override void Exit (Master Entity)
	{
		base.Exit (Entity);
	}
}
