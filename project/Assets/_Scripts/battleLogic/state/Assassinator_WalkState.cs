using UnityEngine;
using System.Collections;

public class Assassinator_WalkState : WalkState {
    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_IdleState());
    }
}
