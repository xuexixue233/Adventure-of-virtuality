using GameFramework.Event;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace AoV
{
    public class ProcedureMain : ProcedureBase
    {
        
        private GameForm m_GameForm = null;
        private AsideForm m_AsideForm = null;

        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("GameForm"), "Default", 1, this);
            //GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("AsideForm"), "Default1", 2, this);

            GameEntry.Entity.ShowPlayer();
            GameEntry.Entity.ShowCamera();
            GameEntry.Entity.ShowEnemy();
            
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            if (m_GameForm != null)
            {
                m_GameForm.Close(isShutdown);
                m_GameForm = null;
            }
            //if (m_AsideForm != null)
            //{
            //    m_AsideForm.Close(isShutdown);
            //    m_AsideForm = null;
            //}


            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            
        }
        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }          
        }
    }
}