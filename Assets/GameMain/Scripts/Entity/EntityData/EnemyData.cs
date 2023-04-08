using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class EnemyData : EntityData
    {
        
        public float waitTime;
        public float radius;
        public float Speed;
        public float backSpeed;
        public Transform movePos;
        public Transform leftDownPos;
        public Transform rightUpPos;
        //public Transform fatherPos;
        private Rigidbody2D coiltran;
        private float wait;
        //private Vector2 coilp;
        //private Vector3 mainp;
        private PlayerHealth playerhit;
        //public float surpisedTime;
        //public GameObject surpriseObject;
        private Transform playerTransform;
        public float AlarmRange;
        public float AttackRange;
        public float ChasingRange;
        public float IdleRange;
        
        public EnemyData(int entityId, int typeId) : base(entityId, typeId)
        {
            IDataTable<DREnemy> dtEnemy = GameEntry.DataTable.GetDataTable<DREnemy>();
            DREnemy drEnemy = dtEnemy.GetDataRow(typeId);
            Position=drEnemy.SpawnPosition;
            Speed=drEnemy.Speed;
            AlarmRange=drEnemy.AlarmRange;
            AttackRange=drEnemy.AttackRange;
            ChasingRange=drEnemy.ChasingRange;
            IdleRange=drEnemy.IdleRange;
        }
    }
}
