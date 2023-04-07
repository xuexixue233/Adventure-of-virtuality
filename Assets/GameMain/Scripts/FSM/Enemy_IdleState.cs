using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class Enemy_IdleState : FsmState<Enemy>
    {
        private Enemy _enemy;
        private float moveTimer;   //�ƶ���ʱ���������ʱ���ƶ�һ��
        private Vector3 targetPos; //Idle�ƶ���ʱ�����Ŀ���
        private float speed; //�ٶ�
        protected override void OnInit(IFsm<Enemy> fsm)
        {
            // ��������״̬��ʱ����
            base.OnInit(fsm);
        }

        protected override void OnDestroy(IFsm<Enemy> fsm)
        {
            // ��������״̬��ʱ����
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Enemy> fsm)
        {
            // ���뱾״̬ʱ����
            base.OnEnter(fsm);
            _enemy = fsm.Owner;


        }

        protected override void OnLeave(IFsm<Enemy> fsm, bool isShutdown)
        {
            // �뿪��״̬ʱ����
            base.OnLeave(fsm, isShutdown);
            _enemy=null;
        }

        protected override void OnUpdate(IFsm<Enemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            // ��״̬����ѯʱ����
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

        }
        /// <summary>
        /// �������һ��0.5-3���Timer 
        /// </summary>
        private void SetMoveTimer()
        {
            moveTimer = Random.Range(0.5f, 3.0f);
        }
        /// <summary>
        /// �������һ��IdleRange�ڵ�Ŀ���
        /// </summary>
        private void SetRandomTargetPos()
        {
            
        }
    }
}
