using UnityEngine;
using System.Collections;

public class Priest_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {
        if (!Entity.animation.IsPlaying("mummy_die"))
        {
            Entity.sendDestoryMessage(Entity.animation.GetClip("mummy_die").length);
            Entity.animation.Play("mummy_die");
        }
    }
}
