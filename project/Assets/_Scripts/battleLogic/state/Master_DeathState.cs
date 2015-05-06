using UnityEngine;
using System.Collections;

public class Master_DeathState : DeathState
{

    public override void EntityDead<T>(T Entity)
    {

        if (!Entity.animation.IsPlaying("skeleton_die"))
        {
            Entity.sendDestoryMessage(Entity.animation.GetClip("skeleton_die").length);
            Entity.animation.Play("skeleton_die");
        }
        
    }

    
}
