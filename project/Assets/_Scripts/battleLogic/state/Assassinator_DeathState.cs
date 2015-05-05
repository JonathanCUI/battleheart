using UnityEngine;
using System.Collections;

public class Assassinator_DeathState : DeathState {

    public override void EntityDead<T>(T Entity)
    {

        if (!Entity.animation.isPlaying)
        {
            Entity.animation.Play("ghost_sleeping");
            Entity.RobotDead(Entity.animation.GetClip("ghost_sleeping").length);
        }
    }
}
