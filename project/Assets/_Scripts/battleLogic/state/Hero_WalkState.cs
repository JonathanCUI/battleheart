using UnityEngine;
using System.Collections;

public class Hero_WalkState : State<HeroRobot> {

	public override void Enter (HeroRobot Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (HeroRobot Entity)
	{
		base.Execute (Entity);	
		Entity.playAnimation("walk");
	}
	
	public override void Exit (HeroRobot Entity)
	{
		base.Exit (Entity);
	}
}
