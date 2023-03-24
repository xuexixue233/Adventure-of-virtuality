using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public class PlayerData : EntityData
    {
        public float jumpspeed;
        public float doublejumpspeed;
        public float restoreTime;
        public float skillcounterforce;
        public GameObject attack1;
        public GameObject attack2;
        public GameObject attack3;
        public ParticleSystem dust;
        public Rigidbody2D myRigidbody;
        public Animator myAnim;
        public BoxCollider2D myFeet;
        public Vector2 trans1;
        public bool isQrun = false;
        public static bool isLorR;
        public bool isGround;
        public bool canDoubleJump;
        public bool isOneWayPlatform;
        public PlayerInputActions controls;
        public PlayerData(int entityId, int typeId) : base(entityId, typeId)
        {
            IDataTable<DRCharacter> dtCharacter =GameEntry.DataTable.GetDataTable<DRCharacter>();
            DRCharacter drCharacter=dtCharacter.GetDataRow(typeId);

            Position= drCharacter.SpawnPosition;
            Runspeed=drCharacter.RunSpeed;
        }
        public int MaxHP;
        public float Runspeed;
    }
}
