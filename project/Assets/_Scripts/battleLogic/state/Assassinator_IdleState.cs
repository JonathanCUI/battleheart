using UnityEngine;
using System.Collections;

/*
刺客闲置状态
*/
public class Assassinator_IdleState : IdleState
{

    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_HuntingState());
    }
}
