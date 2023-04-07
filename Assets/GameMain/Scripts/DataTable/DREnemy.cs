using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace AoV
{
    public class DREnemy : DataRowBase
    {
        private int m_Id;
        public override int Id
        {
            get { return m_Id; }
        }
        public Vector3 SpawnPosition;
        public float AlarmRange;
        public float ChasingRange;
        public float AttackRange;
        public float Speed;
        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
                Log.Debug(columnStrings[i]);
                Log.Debug(columnStrings[i].Length);
            }
            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            string[] rowSpawnPosition = columnStrings[index++].Split('|');
            SpawnPosition = new Vector3(float.Parse(rowSpawnPosition[0]), float.Parse(rowSpawnPosition[1]), float.Parse(rowSpawnPosition[2]));
            index++;
            ChasingRange = float.Parse(columnStrings[index++]);
            AlarmRange = float.Parse(columnStrings[index++]);
            AttackRange=float.Parse(columnStrings[index++]);
            Speed= float.Parse(columnStrings[index++]);

            return true;
        }
    }
}
