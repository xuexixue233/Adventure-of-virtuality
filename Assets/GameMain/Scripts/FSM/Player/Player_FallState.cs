using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class Player_FallState : FsmState<Player>
    {
        private Player _player;
        protected override void OnDestroy(IFsm<Player> fsm)
        {
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Player> fsm)
        {
            base.OnEnter(fsm);
            _player = fsm.Owner;
            _player.SwitchAnimation("Fall");
            
        }

        protected override void OnInit(IFsm<Player> fsm)
        {
            base.OnInit(fsm);
        }

        protected override void OnLeave(IFsm<Player> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            _player = null;
        }

        protected override void OnUpdate(IFsm<Player> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            _player.CheckGrounded();
            if (_player.isGround)
            {
                ChangeState<Player_IdleState>(fsm);
            }
            else
            {
                float movedir = Input.GetAxis("Horizontal");
                if (movedir != 0)
                {
                    if (_player.isQrun)
                    {
                        _player.Run(movedir);
                    }
                    else
                    {
                        _player.Walk(movedir);
                    }
                    _player.OneWayPlatformCheck();
                }
            }
        }
    }
}
