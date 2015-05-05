using UnityEngine;
using System.Collections;

public class Master_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {
        
        if (!Entity.animation.isPlaying)
        {
            Entity.animation.Play("skeleton_die");
            Entity.RobotDead(Entity.animation.GetClip("skeleton_die").length);
        }
    }

    
}
