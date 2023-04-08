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
        private float speed; //�ٶ�
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
            //׷�����
            Vector3 direction = Vector3.Normalize(targetTran.position - _enemy.transform.position);
            _enemy.transform.Translate(direction * speed * elapseSeconds);

            //���������׷��Ļ��Χ����뷵��״̬
            if (_enemy.IsOutOfChasingRange())
            {
                ChangeState<Enemy_ReturningState>(fsm);
                return;
            }
            //��������˹�����Χ����빥��״̬
            if (_enemy.IsInAttackRange())
            {
                ChangeState<Enemy_AttackingState>(fsm);
            }
        }
    }
}
