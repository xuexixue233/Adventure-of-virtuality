using GameFramework.Event;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace AoV
{
    public class ProcedureMain : ProcedureBase
    {
        //private const float GameOverDelayedSeconds = 2f;

        //private readonly Dictionary<GameMode, GameBase> m_Games = new Dictionary<GameMode, GameBase>();
        //private GameBase m_CurrentGame = null;
        //private bool m_GotoMenu = false;
        //private float m_GotoMenuDelaySeconds = 0f;
        private GameForm m_GameForm = null;
        private AsideForm m_AsideForm = null;

        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        //public void GotoMenu()
        //{
        //    m_GotoMenu = true;
        //}

        //protected override void OnInit(ProcedureOwner procedureOwner)
        //{
        //    base.OnInit(procedureOwner);

        //    m_Games.Add(GameMode.Survival, new SurvivalGame());
        //}

        //protected override void OnDestroy(ProcedureOwner procedureOwner)
        //{
        //    base.OnDestroy(procedureOwner);

        //    m_Games.Clear();
        //}

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("GameForm"), "Default", 1, this);
            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("AsideForm"), "Default1", 2, this);

            GameEntry.Entity.ShowPlayer();
            GameEntry.Entity.ShowCamera();
            GameEntry.Entity.ShowEnemy();
            //m_GotoMenu = false;
            //GameMode gameMode = (GameMode)procedureOwner.GetData<VarByte>("GameMode").Value;
            //m_CurrentGame = m_Games[gameMode];
            //m_CurrentGame.Initialize();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            if (m_GameForm != null)
            {
                m_GameForm.Close(isShutdown);
                m_GameForm = null;
            }
            if (m_AsideForm != null)
            {
                m_AsideForm.Close(isShutdown);
                m_AsideForm = null;
            }


            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            //if (m_CurrentGame != null && !m_CurrentGame.GameOver)
            //{
            //    m_CurrentGame.Update(elapseSeconds, realElapseSeconds);
            //    return;
            //}

            //if (!m_GotoMenu)
            //{
            //    m_GotoMenu = true;
            //    m_GotoMenuDelaySeconds = 0;
            //}

            //m_GotoMenuDelaySeconds += elapseSeconds;
            //if (m_GotoMenuDelaySeconds >= GameOverDelayedSeconds)
            //{
            //    procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Menu"));
            //    ChangeState<ProcedureChangeScene>(procedureOwner);
            //}
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