using UnityEngine;
using System.Collections;

public class Ranger_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {

        if (!Entity.animation.isPlaying)
        {
            Entity.animation.Play("dragon_die");
            Entity.RobotDead(Entity.animation.GetClip("dragon_die").length);
        }
    }
}
