﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Assassinator_AttackState : AttackState
{
    public override void changeToWalkState<T>(T Entity)
    {
        Entity.changeState(new Assassinator_WalkState());
    }


    public override void AttackingTarget<T>(T Entity)
    {
        Dictionary<int, BaseRobot> opps = Entity.GameTargets;
        if (opps != null && opps.Count != 0)
        {
            //Entity.playAnimation ("walk");
            float relativeDistance = 100000f, minDistance = 100000f;
            int first_id = -1, second_id = -1;
            foreach (KeyValuePair<int, BaseRobot> kv in opps)
            {

                float dis = Vector3.Distance(Entity.getPosition(), kv.Value.getPosition());
                if (kv.Value.AttackType == BattleConfig.AttackType.LONG || kv.Value.AttackType == BattleConfig.AttackType.SUPPORT)
                {//判断远程或辅助 选取距离最近的目标

                    if (dis < relativeDistance)
                    {
                        first_id = kv.Key;
                        relativeDistance = dis;
                    }
                }

                if (dis < minDistance)
                {//选取距离最近的目标
                    second_id = kv.Key;
                    minDistance = dis;
                }
            }
            BaseRobot targetEnmy = opps[first_id != -1 ? first_id : second_id];

            float disx = Vector3.Distance(Entity.getPosition(), targetEnmy.getPosition());

            if (disx > Entity.AttackDistance)
            {
                Entity.changeState(new Assassinator_HuntingState());
            }
            else
            {
                Entity.transform.LookAt(targetEnmy.getPosition());
                Entity.playAnimation("punch");
            }

        }
    }
}