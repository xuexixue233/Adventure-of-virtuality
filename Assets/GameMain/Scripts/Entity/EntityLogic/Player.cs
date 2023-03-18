using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace AoV
{
    public class Player : EntityLogic
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            CachedTransform.position = ((PlayerData)userData).Position;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        }

        protected override void OnUpdate(float elapseSeconds,float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}
