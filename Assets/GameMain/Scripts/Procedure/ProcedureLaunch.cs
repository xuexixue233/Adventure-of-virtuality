using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace AoV
{
    public class ProcedureLaunch : ProcedureBase
    {

        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            //一帧后直接转到预备流程
            ChangeState<ProcedurePreload>(procedureOwner);
        }
    }
}
