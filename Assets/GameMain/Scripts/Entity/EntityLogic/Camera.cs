using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using static UnityEngine.GraphicsBuffer;

namespace AoV
{
    public class Camera : EntityLogic
    {
        private CameraData m_CameraData;
        private GameObject m_Target;
        public Transform target;
        public Vector2 minPosition;
        public Vector2 maxPosition=new Vector2 (1350,950);
        public float smoothing = (float)0.1;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_CameraData= userData as CameraData;
            CachedTransform.position= m_CameraData.Position;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_Target = GameObject.FindGameObjectWithTag(m_CameraData.Target);
            Log.Debug(m_CameraData.Target);
            target = m_Target.transform;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            if (target != null)
            {
                if (transform.position != target.position)
                {
                    Vector3 targetPos = target.position+new Vector3(0,0,-1);

                    targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);

                    targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                    transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
                }
            }
        }
    }
}
