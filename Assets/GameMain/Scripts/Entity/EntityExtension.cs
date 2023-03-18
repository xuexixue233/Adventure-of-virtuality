using GameFramework.DataTable;
using GameFramework.Entity;
using System;
using Unity.Burst.CompilerServices;
using UnityGameFramework.Runtime;

namespace AoV
{
    public static class EntityExtension
    {
        private static int s_SerialId = 0;

        public static void ShowPlayer(this EntityComponent entityComponent)
        {
            //创建玩家实体数据
            PlayerData playerdata = new PlayerData(GameEntry.Entity.GenerateSerialId(), 1000);

            //读取数据表Entity
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(playerdata.TypeId);

            //加载Entity
            GameEntry.Entity.ShowEntity<Player>(playerdata.Id, AssetUtility.GetEntityAsset(drEntity.AssetName), "DefaultGroup", playerdata);
        }
        private static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, priority, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }
    }
}
