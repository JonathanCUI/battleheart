using UnityEngine;
using System.Collections;

/*
生命补助闲置状态
*/
public class Medic_IdleState : IdleState
{

    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Medic_TreatingState());
    }
}
