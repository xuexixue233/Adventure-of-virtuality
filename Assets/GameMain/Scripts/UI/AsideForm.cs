using AoV;
using GameFramework.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;


namespace AoV
{
    public class AsideForm : UGuiForm
    {
        private ProcedureMain m_ProcedureMain = null;


#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);

            m_ProcedureMain = (ProcedureMain)userData;
            if (m_ProcedureMain == null)
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
            m_ProcedureMain = null;

            base.OnClose(isShutdown, userData);
        }
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);


        }
    }
}
