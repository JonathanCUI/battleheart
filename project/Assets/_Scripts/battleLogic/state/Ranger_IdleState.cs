using UnityEngine;
using System.Collections;

/*
刺客闲置状态
*/
public class Ranger_IdleState : IdleState
{

    public override void ChangeState<T>(T Entity)
    {
        Entity.changeState(new Ranger_HuntingState());
    }
}
