using AoV;
using GameFramework.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace AoV
{
    public class MenuForm : UGuiForm
    {

        public Button m_StartButton = null;
        public Button m_LoadButton = null;
        public Button m_QuitButton = null;

        private ProcedureMenu m_ProcedureMenu = null;

        private void OnStartButtonClick()
        {
            m_ProcedureMenu.StartGame();
        }

        private void OnLoadButtonClick()
        {
            //m_ProcedureMenu.LoadGame();
        }


        public void OnQuitButtonClick()
        {
            //GameEntry.UI.OpenDialog(new DialogParams()
            //{
            //    Mode = 2,
            //    Title = GameEntry.Localization.GetString("AskQuitGame.Title"),
            //    Message = GameEntry.Localization.GetString("AskQuitGame.Message"),
            //    OnClickConfirm = delegate (object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
            //});
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);

            m_ProcedureMenu = (ProcedureMenu)userData;
            if (m_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }

            
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnClose(bool isShutdown, object userData)
#else
        protected internal override void OnClose(bool isShutdown, object userData)
#endif
        {
            m_ProcedureMenu = null;

            base.OnClose(isShutdown, userData);
        }
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            //添加按钮事件
            m_StartButton.onClick.AddListener(OnStartButtonClick);
            m_LoadButton.onClick.AddListener(OnLoadButtonClick);
            m_QuitButton.onClick.AddListener(OnQuitButtonClick);

        }
    }
}