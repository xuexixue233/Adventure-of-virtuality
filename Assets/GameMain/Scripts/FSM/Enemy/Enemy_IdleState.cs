using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class Enemy_IdleState : FsmState<Enemy>
    {
        private Enemy _enemy;
        private float moveTimer;   //移动计时器，归零的时候移动一次
        private Vector3 targetPos; //Idle移动的时候的随目标点
        private float speed;
        public int left = -1;
        protected override void OnInit(IFsm<Enemy> fsm)
        {
            // 创建有限状态机时调用
            base.OnInit(fsm);
        }

        protected override void OnDestroy(IFsm<Enemy> fsm)
        {
            // 销毁有限状态机时调用
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Enemy> fsm)
        {
            // 进入本状态时调用
            base.OnEnter(fsm);
            _enemy = fsm.Owner;
            _enemy.SwitchAnimation("Idle");
            speed=_enemy.Speed;
            SetTargetPos();
        }

        protected override void OnLeave(IFsm<Enemy> fsm, bool isShutdown)
        {
            // 离开本状态时调用
            base.OnLeave(fsm, isShutdown);
            _enemy=null;
        }

        protected override void OnUpdate(IFsm<Enemy> fsm, float elapseSeconds, float realElapseSeconds)
        {
            // 本状态被轮询时调用
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (Vector3.Distance(targetPos, _enemy.transform.position) > 1)
            {
                //如果还没有到达目标位置
                //向目标位置移动
                Vector3 direction = Vector3.Normalize(targetPos - _enemy.transform.position);
                _enemy.transform.Translate(direction * speed * elapseSeconds*left);
            }
            else
            {
                _enemy.FaceToLeft = !_enemy.FaceToLeft;
                left = left * -1;
                SetTargetPos();
            }
            //如果玩家进入了发现范围，则进入追逐状态
            if (_enemy.IsPlayerFound())
            {
                ChangeState<Enemy_ChasingState>(fsm);//状态机的状态切换
            }
        }
        /// <summary>
        /// 随机设置一个IdleRange内的目标点
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
