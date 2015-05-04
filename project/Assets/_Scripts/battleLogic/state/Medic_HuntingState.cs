using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Desmond
 * 肉盾搜寻目标状态
 **/
public class Medic_HuntingState : HuntingState
{

    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Medic_WalkState());
    }

    public override void changeToIdleState<T>(T Entity)
    {
        Entity.changeState(new Medic_IdleState());
    }

    public override void changeToATKState<T>(T Entity, T enemy)
    {
        Entity.changeState(new Medic_AttackState(enemy));
    }

    //寻找对手AI策略
    public override void huntingStrategy<T>(T Entity)
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


            changeToATKState(Entity, targetteammate);
        }
        else
        {
            changeToIdleState(Entity);
        }
    }

}
