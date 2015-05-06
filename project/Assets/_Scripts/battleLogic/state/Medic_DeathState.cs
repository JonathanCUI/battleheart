using UnityEngine;
using System.Collections;

public class Medic_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {
        if (!Entity.animation.IsPlaying("zombie_die"))
        {
            Entity.sendDestoryMessage(Entity.animation.GetClip("zombie_die").length);
            Entity.animation.Play("zombie_die");
        }
    }
}
