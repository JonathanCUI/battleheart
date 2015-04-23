using UnityEngine;
using System.Collections;

public class Medic_WalkState : WalkState {
    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Medic_IdleState());
    }
}
