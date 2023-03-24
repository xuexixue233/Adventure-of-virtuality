
using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class CameraData : EntityData
    {
        public string Target;
        public float smoothing;
        public Vector2 minPosition;
        public Vector2 maxPosition;

        public CameraData(int entityId, int typeId) : base(entityId, typeId)
        {
            IDataTable<DRCamera> dtCamera = GameEntry.DataTable.GetDataTable<DRCamera>();
            DRCamera drCamera = dtCamera.GetDataRow(typeId);
            Position = drCamera.SpawnPosition;
            Target = drCamera.Target;
        }
    }
}
