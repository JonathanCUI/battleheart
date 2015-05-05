using UnityEngine;
using System.Collections;

public class Mangler_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {

        if (!Entity.animation.isPlaying)
        {
            Entity.animation.Play("death");
            Entity.RobotDead(Entity.animation.GetClip("death").length);
        }
    }
}
