using UnityEngine;
using System.Collections;

public class Master_WalkState : WalkState {
	public override void ChangeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Master_IdleState());
    }
}
