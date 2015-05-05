using UnityEngine;
using System.Collections;

public class Medic_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {

        if (!Entity.animation.isPlaying)
        {
            Entity.animation.Play("zombie_die");
            Entity.RobotDead(Entity.animation.GetClip("zombie_die").length);
        }
    }
}
