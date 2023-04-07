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
        private float speed; //速度
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

        }
        /// <summary>
        /// 随机设置一个0.5-3秒的Timer 
        /// </summary>
        private void SetMoveTimer()
        {
            moveTimer = Random.Range(0.5f, 3.0f);
        }
        /// <summary>
        /// 随机设置一个IdleRange内的目标点
        /// </summary>
        private void SetRandomTargetPos()
        {
            
        }
    }
}
