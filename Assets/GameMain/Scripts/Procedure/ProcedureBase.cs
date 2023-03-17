using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    /// <summary>
    /// 流程抽象类
    /// </summary>
    public abstract class ProcedureBase : GameFramework.Procedure.ProcedureBase
    {
        public abstract bool UseNativeDialog
        {
            get;
        }
    }
}
