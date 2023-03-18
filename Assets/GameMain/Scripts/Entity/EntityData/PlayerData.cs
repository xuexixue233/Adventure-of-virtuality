using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class PlayerData : EntityData
    {
        public PlayerData(int entityId, int typeId) : base(entityId, typeId)
        {
            IDataTable<DRCharacter> dtCharacter =GameEntry.DataTable.GetDataTable<DRCharacter>();
            DRCharacter drCharacter=dtCharacter.GetDataRow(typeId);

            Position= drCharacter.SpawnPosition;
        }
    }
}
