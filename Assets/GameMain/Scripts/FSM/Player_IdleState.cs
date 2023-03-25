using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace AoV
{
    public class Player_IdleState : FsmState<Player>
    {
        private Player _player;
        protected override void OnInit(IFsm<Player> fsm)
        {
            // 创建有限状态机时调用
            base.OnInit(fsm);
        }

        protected override void OnDestroy(IFsm<Player> fsm)
        {
            // 销毁有限状态机时调用
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Player> fsm)
        {
            // 进入本状态时调用
            base.OnEnter(fsm);
            _player = fsm.Owner;

        }

        protected override void OnLeave(IFsm<Player> fsm, bool isShutdown)
        {
            // 离开本状态时调用
            base.OnLeave(fsm, isShutdown);
            _player = null;
        }

        protected override void OnUpdate(IFsm<Player> fsm, float elapseSeconds, float realElapseSeconds)
        {
            // 本状态被轮询时调用
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            float movedir = Input.GetAxis("Horizontal");
            if (movedir != 0)
            {
                ChangeState<Player_WalkState>(fsm);
            }
        }
    }
}
