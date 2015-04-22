using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 肉盾闲置状态
 **/
public class Mangler_IdleState : State<Mangler> {
	
	public override void Enter (Mangler Entity)
	{
		base.Enter (Entity);
		//Entity.playAnimation("walk");
	}
	
	public override void Execute (Mangler Entity)
	{
		base.Execute (Entity);
		//进入搜寻对手转态
		Entity.changeState (new Mangler_HuntingState ());
		
	}
	
	public override void Exit (Mangler Entity)
	{
		base.Exit (Entity);
	}
}
