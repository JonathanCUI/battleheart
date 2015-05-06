using UnityEngine;
using System.Collections;

public class Mangler_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {
        if (!Entity.animation.IsPlaying("death"))
        {
            Entity.sendDestoryMessage(Entity.animation.GetClip("death").length);
            Entity.animation.Play("death");
        }
    }
}
