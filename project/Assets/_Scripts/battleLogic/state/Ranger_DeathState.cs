using UnityEngine;
using System.Collections;

public class Ranger_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {

        if (!Entity.animation.IsPlaying("dragon_die"))
        {
            Entity.sendDestoryMessage(Entity.animation.GetClip("dragon_die").length);
            Entity.animation.Play("dragon_die");
        }
    }
}
