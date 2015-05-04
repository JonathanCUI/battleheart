using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Desmond
 * 生命补助治疗目标状态
 **/

public class Medic_AttackState : AttackState
{
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Medic_WalkState());
    }

    public override void AttackingTarget<T>(T Entity)
    {
        Entity.playAnimation("zombie_bite");
        baseAttackingTarget(Entity, BattleConfig.PriorityStrategy.SELF_LIFE);
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Medic_HuntingState());
    }

    public override void changeToHuntingState<T>(T Entity)
    {
        Entity.changeState(new Medic_HuntingState());
    }

    public virtual void baseAttackingTarget<T>(T Entity, BattleConfig.PriorityStrategy priorityStrategy) where T : BaseRobot
    {
        Dictionary<int, BaseRobot> opps = Entity.GameTargets;
        if (opps != null && opps.Count != 0)
        {
            int leastlifepoint = 100000000;
            int first_id = -1;
            BaseRobot targetteammate;           //治疗目标
            if (Entity.CurrentLifePoint < Entity.LifePoint)
            {
                //治疗自身
                targetteammate = Entity;
            }
            else
            {
                foreach (KeyValuePair<int, BaseRobot> kv in opps)
                {
                    if (kv.Value.CurrentLifePoint < kv.Value.LifePoint)
                    {
                        if (kv.Value.CurrentLifePoint < leastlifepoint)
                        {
                            first_id = kv.Key;
                        }
                    }
                }
                if (first_id != -1)
                {
                    targetteammate = opps[first_id];
                }
                else
                {
                    changeToIdleState(Entity);
                    targetteammate = Entity;
                }

                Entity.transform.LookAt(targetteammate.getPosition());
            }

            //根据治疗目标进行治疗


        }
        else
        {
            changeToIdleState(Entity);
        }
    }
    
}
