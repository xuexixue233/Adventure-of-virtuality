using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace AoV
{
    public class Enemy : EntityLogic
    {
        public GameObject Attack;
        public Animator myAnim;
        public Transform targetTran;
        public float Speed;
        private IFsm<Enemy> fsm;
        public EnemyData m_EnemyData;
        public bool FaceToLeft=false;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            CachedTransform.position = ((EnemyData)userData).Position;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_EnemyData = (EnemyData)userData;
            Speed = m_EnemyData.Speed;
            myAnim=GetComponent<Animator>();
            Attack = transform.Find("attack").gameObject;
            targetTran = GameObject.FindGameObjectWithTag("Player").transform;
            List<FsmState<Enemy>> states = new List<FsmState<Enemy>>() {new Enemy_IdleState(),new Enemy_AttackingState(),new Enemy_ReturningState(),new Enemy_ChasingState()};
            fsm = GameEntry.Fsm.CreateFsm<Enemy>("Enemy_Fsm", this, states);
            fsm.Start<Enemy_IdleState>();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            
        }

        public void SwitchAnimation(string State)
        {
            
            switch (State)
            {
                case "Idle":
                    myAnim.SetBool("attack", false);
                    myAnim.SetBool("look", false);
                    break;
                case "Attack":
                    myAnim.SetBool("attack",true);
                    break;
                case "Chasing":
                    myAnim.SetBool("look", true);
                    break;
            }

        }
        /// <summary>
        /// �Ƿ��Ѿ���������ң��������Ƿ���Alarm��Χ�ڣ�
        /// </summary>
        /// <returns></returns>
        public bool IsPlayerFound()
        {
            return Vector3.Distance(transform.position, targetTran.position) < m_EnemyData.AlarmRange;
        }
        /// <summary>
        /// ����Ƿ���Enemy�Ĺ�����Χ
        /// </summary>
        /// <returns></returns>
        public bool IsInAttackRange()
        {
            return Vector3.Distance(transform.position, targetTran.position) < m_EnemyData.AttackRange;
        }
        /// <summary>
        /// Enemy�Ƿ񳬳���׷��Χ
        /// </summary>
        /// <returns></returns>
        public bool IsOutOfChasingRange()
        {
            return Vector3.Distance(transform.position, m_EnemyData.Position) > m_EnemyData.ChasingRange;
        }
        public bool IsInIdleRange()
        {
            return Vector3.Distance(transform.position, m_EnemyData.Position) < m_EnemyData.IdleRange;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            GameEntry.Fsm.DestroyFsm(fsm);
            fsm = null;
        }
    }
}
