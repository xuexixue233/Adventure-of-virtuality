using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    /// <summary>
    /// ���̳�����
    /// </summary>
    public abstract class ProcedureBase : GameFramework.Procedure.ProcedureBase
    {
        public abstract bool UseNativeDialog
        {
            get;
        }
    }
}
