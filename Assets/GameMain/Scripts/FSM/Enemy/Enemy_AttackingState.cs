using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class Enemy_AttackingState : FsmState<Enemy>
    {
        private Enemy _enemy;
        private float moveTimer;   //�ƶ���ʱ���������ʱ���ƶ�һ��
        private Vector3 targetPos; //Idle�ƶ���ʱ�����Ŀ���
        private float speed; //�ٶ�
        public Transform targetTran;

        protected override void OnDestroy(IFsm<Enemy> fsm)
        {
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Enemy> fsm)
        {
            base.OnEnter(fsm);
            _enemy = fsm.Owner;
            _enemy.SwitchAnimation("Attack");
            targetTran = _enemy.targetTran;
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
            //��������Ŀ��
            Vector3 direction = Vector3.Normalize(targetTran.position - _enemy.transform.position);
            _enemy.transform.Translate(direction * speed * elapseSeconds);

            //��������˹�����Χ �����׷��״̬
            if (!_enemy.IsInAttackRange())
            {
                ChangeState<Enemy_ChasingState>(fsm);
            }
        }
    }
}

