using UnityEngine;
using System.Collections;

public class AttackState : IState
{
    public virtual void Enter<T>(T Entity) where T : BaseRobot
    {
        //Entity.playAnimation("walk");
    }

    public virtual void Execute<T>(T Entity) where T : BaseRobot
    {
        if (Entity.userPointed())
        {//玩家指定位置
            changeToWalkState(Entity);
            return;
        }

        AttackingTarget(Entity);
    }

    public virtual void Exit<T>(T Entity) where T : BaseRobot
    {

    }

    //状态变换为walk
    public virtual void changeToWalkState<T>(T Entity) where T : BaseRobot
    {
        Entity.changeState(new WalkState());
    }

    public virtual void changeToHuntingState<T>(T Entity) where T : BaseRobot
    {
        Entity.changeState(new WalkState());
    }

    //攻击、治疗目标
    public virtual void AttackingTarget<T>(T Entity) where T : BaseRobot
    {
    }
}
