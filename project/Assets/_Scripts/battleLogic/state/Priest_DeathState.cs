using UnityEngine;
using System.Collections;

public class Priest_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {

        if (!Entity.animation.isPlaying)
        {
            Entity.animation.Play("mummy_die");
            Entity.RobotDead(Entity.animation.GetClip("mummy_die").length);
        }
    }
}
