using UnityEngine;
using System.Collections;

public class Master_WalkState : WalkState {
    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Master_IdleState());
    }
}
