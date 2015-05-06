using UnityEngine;
using System.Collections;

public class Assassinator_DeathState : DeathState {

    public override void EntityDead<T>(T Entity)
    {
        if (!Entity.animation.IsPlaying("ghost_sleeping"))
        {
            Entity.sendDestoryMessage(Entity.animation.GetClip("ghost_sleeping").length);
            Entity.animation.Play("ghost_sleeping");
        }
    }
}
