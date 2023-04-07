using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace AoV
{
    public class ProcedurePlot : ProcedureBase
    {
        public override bool UseNativeDialog => throw new System.NotImplementedException();

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);

        }
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

        }
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            
            base.OnLeave(procedureOwner, isShutdown);
        }
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);

        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }

    }

}
