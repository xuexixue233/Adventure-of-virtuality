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
        private float speed;
        public int left = -1;
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
            _enemy.SwitchAnimation("Idle");
            speed=_enemy.Speed;
            SetTargetPos();
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

            if (Vector3.Distance(targetPos, _enemy.transform.position) > 1)
            {
                //�����û�е���Ŀ��λ��
                //��Ŀ��λ���ƶ�
                Vector3 direction = Vector3.Normalize(targetPos - _enemy.transform.position);
                _enemy.transform.Translate(direction * speed * elapseSeconds*left);
            }
            else
            {
                _enemy.FaceToLeft = !_enemy.FaceToLeft;
                left = left * -1;
                SetTargetPos();
            }
            //�����ҽ����˷��ַ�Χ�������׷��״̬
            if (_enemy.IsPlayerFound())
            {
                ChangeState<Enemy_ChasingState>(fsm);//״̬����״̬�л�
            }
        }
        /// <summary>
        /// �������һ��IdleRange�ڵ�Ŀ���
        /// </summary>
        private void SetTargetPos()
        { 
            if(_enemy.FaceToLeft)
            {
                targetPos = new Vector3(_enemy.m_EnemyData.Position.x + _enemy.m_EnemyData.IdleRange, _enemy.transform.position.y, _enemy.transform.position.z);
                _enemy.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                targetPos = new Vector3(_enemy.m_EnemyData.Position.x - _enemy.m_EnemyData.IdleRange, _enemy.transform.position.y, _enemy.transform.position.z);
                _enemy.transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
}
