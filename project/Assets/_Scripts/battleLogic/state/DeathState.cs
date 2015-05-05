using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 死亡状态 base
 **/

public class DeathState : IState
{
    
    public virtual void Enter<T>(T Entity) where T : BaseRobot
    {
    }

    public virtual void Execute<T>(T Entity) where T : BaseRobot
    {
        EntityDead(Entity);
    }

    public virtual void Exit<T>(T Entity) where T : BaseRobot
    {
        
    }

    

    public virtual void EntityDead<T>(T Entity) where T : BaseRobot
    {
        if (!Entity.animation.isPlaying)
        {
            Entity.RobotDead();
        }
    }

}
