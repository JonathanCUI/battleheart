using UnityEngine;
using System.Collections;

/*
刺客闲置状态
*/
public class Priest_IdleState : IdleState
{

	public override void ChangeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Priest_HuntingState());
    }
}
