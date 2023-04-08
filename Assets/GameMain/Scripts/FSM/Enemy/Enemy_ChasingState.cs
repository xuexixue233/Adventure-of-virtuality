using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class Enemy_ChasingState : FsmState<Enemy>
    {
        private Enemy _enemy;
        private Transform targetTran;
        private float speed; //速度
        protected override void OnDestroy(IFsm<Enemy> fsm)
        {
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Enemy> fsm)
        {
            base.OnEnter(fsm);
            _enemy = fsm.Owner;
            targetTran = _enemy.targetTran;
            speed = _enemy.m_EnemyData.Speed;
        }

        protected override void OnInit(IFsm<Enemy> fsm)
        {
            base.OnInit(fsm);
            
        }

        protected override void OnLeave(IFsm<Enemy> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            _enemy = null;
            targetTran = null;
        }

        protected override void OnUpdate(IFsm<Enemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            //追逐玩家
            Vector3 direction = Vector3.Normalize(targetTran.position - _enemy.transform.position);
            _enemy.transform.Translate(direction * speed * elapseSeconds);

            //如果超出了追逐的活动范围则进入返回状态
            if (_enemy.IsOutOfChasingRange())
            {
                ChangeState<Enemy_ReturningState>(fsm);
                return;
            }
            //如果进入了攻击范围则进入攻击状态
            if (_enemy.IsInAttackRange())
            {
                ChangeState<Enemy_AttackingState>(fsm);
            }
        }
    }
}
