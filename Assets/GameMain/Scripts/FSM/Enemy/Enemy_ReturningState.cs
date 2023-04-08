using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace AoV
{
    public class Enemy_ReturningState : FsmState<Enemy>
    {
        private Enemy _enemy;
        private float speed;
        private float timer;
        protected override void OnDestroy(IFsm<Enemy> fsm)
        {
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Enemy> fsm)
        {
            base.OnEnter(fsm);
            _enemy = fsm.Owner;
            speed = _enemy.m_EnemyData.Speed;
            timer = 2.0f;
        }

        protected override void OnInit(IFsm<Enemy> fsm)
        {
            base.OnInit(fsm);
        }

        protected override void OnLeave(IFsm<Enemy> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            _enemy = null;
        }

        protected override void OnUpdate(IFsm<Enemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            //��Enemy��ԭ���ƶ�
            Vector3 direction = Vector3.Normalize(_enemy.m_EnemyData.Position - _enemy.transform.position);
            _enemy.transform.Translate(direction * speed * elapseSeconds);

            if (timer > 0)
            {
                timer -= elapseSeconds;
            }
            else
            {
                //��ҽ��뷢�ַ�Χ ת����  ׷��״̬
                if (_enemy.IsPlayerFound())
                {
                    ChangeState<Enemy_ChasingState>(fsm);
                    return;
                }
            }
            //Enemy������Ѳ�߷�Χ ��ת��Ѳ��״̬
            if (_enemy.IsInIdleRange())
            {
                ChangeState<Enemy_IdleState>(fsm);
            }
        }
    }
}
