using UnityEngine;
using System.Collections;

/*
法师闲置状态
*/
public class Master_IdleState : IdleState
{

    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Master_HuntingState());
    }
}
