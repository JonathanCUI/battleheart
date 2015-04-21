using UnityEngine;
using System.Collections;

public class Medic_WalkState : State<Medic> {
	
	public override void Enter (Medic Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (Medic Entity)
	{
		base.Execute (Entity);	
		Entity.playAnimation("walk");
	}
	
	public override void Exit (Medic Entity)
	{
		base.Exit (Entity);
	}
}
