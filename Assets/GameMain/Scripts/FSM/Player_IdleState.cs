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
            // ��������״̬��ʱ����
            base.OnInit(fsm);
        }

        protected override void OnDestroy(IFsm<Player> fsm)
        {
            // ��������״̬��ʱ����
            base.OnDestroy(fsm);
        }

        protected override void OnEnter(IFsm<Player> fsm)
        {
            // ���뱾״̬ʱ����
            base.OnEnter(fsm);
            _player = fsm.Owner;

        }

        protected override void OnLeave(IFsm<Player> fsm, bool isShutdown)
        {
            // �뿪��״̬ʱ����
            base.OnLeave(fsm, isShutdown);
            _player = null;
        }

        protected override void OnUpdate(IFsm<Player> fsm, float elapseSeconds, float realElapseSeconds)
        {
            // ��״̬����ѯʱ����
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            float movedir = Input.GetAxis("Horizontal");
            if (movedir != 0)
            {
                ChangeState<Player_WalkState>(fsm);
            }
        }
    }
}
