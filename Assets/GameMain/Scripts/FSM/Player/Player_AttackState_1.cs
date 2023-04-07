using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class Player_AttackState_1 : FsmState<Player>
    {
        private Player _player;
        AnimatorStateInfo animatorInfo;
        
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
            _player.SwitchAnimation("Attack1");            
        }

        protected override void OnLeave(IFsm<Player> fsm, bool isShutdown)
        {
            // 离开本状态时调用
            base.OnLeave(fsm, isShutdown);
            _player = null;
        }

        protected override void OnUpdate(IFsm<Player> fsm, float elapseSeconds, float realElapseSeconds)
        {
            animatorInfo = _player.myAnim.GetCurrentAnimatorStateInfo(0);
            // 本状态被轮询时调用
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            if(Input.GetMouseButtonDown(0))
            {
                ChangeState<Player_AttackState_2>(fsm);
            }
            if (animatorInfo.normalizedTime >= 0.9f)
            {
                _player.myAnim.SetFloat("numattack", 0);
                ChangeState<Player_IdleState>(fsm);
            }
        }
        
    }
}
