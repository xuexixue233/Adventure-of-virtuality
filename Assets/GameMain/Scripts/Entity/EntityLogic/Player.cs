using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace AoV
{
    public class Player : EntityLogic
    {

        private IFsm<Player> fsm;
        private PlayerData m_PlayerData;

        [Header("-- Normal --")]
        public float runspeed;
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
        private BoxCollider2D myFeet;
        private Vector2 trans1;
        public bool isQrun = false;
        public static bool isLorR;
        public bool isGround;
        private bool canDoubleJump;
        private bool isOneWayPlatform;
        private PlayerInputActions controls;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            CachedTransform.position = ((PlayerData)userData).Position;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_PlayerData= userData as PlayerData;

            myRigidbody = GetComponent<Rigidbody2D>();
            myAnim = GetComponent<Animator>();
            myFeet = GetComponent<BoxCollider2D>();

            runspeed = m_PlayerData.Runspeed;
            jumpspeed = m_PlayerData.Jumpspeed;

            List<FsmState<Player>> states = new List<FsmState<Player>>() { new Player_IdleState(),new Player_WalkState(),new Player_RunState(),new Player_JumpState(),new Player_FallState()};
            fsm = GameEntry.Fsm.CreateFsm<Player>("Player_Fsm", this, states);
            fsm.Start<Player_IdleState>();
                        
        }

        protected override void OnUpdate(float elapseSeconds,float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            PlayerUpdate();
        }



        // Update is called once per frame
        void PlayerUpdate()
        {
            GameController.CurrentPlayer = gameObject;

            trans1 = transform.position;

            //判断是否快跑
            if (Input.GetButtonDown("Speed"))
            {
                isQrun = !isQrun;
            }
            ////放技能后坐力
            //if (SkillAttack.skilling)
            //{
            //    if (isLorR == true)
            //    {
            //        trans1.x -= skillcounterforce;
            //    }
            //    else
            //    {
            //        trans1.x += skillcounterforce;
            //    }
            //    transform.position = trans1;
            //    SkillAttack.skilling = false;
            //}
        }
        public void CheckGrounded()
        {
            isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                 myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
                 myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
            isOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        }
        public void Trun()
        {
            bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            if (playerHasXAxisSpeed)
            {
                if (myRigidbody.velocity.x > 0.1f)
                {
                    isLorR = true;
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                if (myRigidbody.velocity.x < -0.1f)
                {
                    isLorR = false;
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }
        public void Walk(float movedir)
        {
            
            myAnim.SetFloat("runSpeed", Mathf.Abs(movedir));
            Vector2 playervel = new Vector2(movedir * runspeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playervel;

        }
        public void Run(float movedir)
        {
            movedir = movedir * 3;
            myAnim.SetFloat("runSpeed", Mathf.Abs(movedir));
            Vector2 playervel = new Vector2(movedir * runspeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playervel;

        }
        public void Jump()
        {
            if (isGround)
            {
                Vector2 JumpVel = new Vector2(0.0f, jumpspeed);
                myRigidbody.velocity = Vector2.up * JumpVel;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump && myAnim.GetBool("idle") == false)
                {
                    Vector2 doubleJumpVel = new Vector2(0.0f, doublejumpspeed);
                    myRigidbody.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                }
            }
        }
        public void SwitchAnimation(string State)
        {
            myAnim.SetBool("idle", false);
            myAnim.SetBool("run", false);
            myAnim.SetBool("jump", false);
            myAnim.SetBool("fall", false);
            switch(State)
            {
                case "Idle":
                    myAnim.SetBool("idle", true);
                    break;
                case "Run":
                    myAnim.SetBool("run", true);
                    break;
                case "Jump":
                    myAnim.SetBool("jump", true);
                    break;
                case "Fall":
                    myAnim.SetBool("fall", true);
                    break;
            }
            
        }
        public void OneWayPlatformCheck()
        {
            if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
            float moveY = Input.GetAxis("Vertical");
            if (isOneWayPlatform && moveY < 0.1f)
            {
                gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
                Invoke("RestorePlayerLayer", restoreTime);
            }
        }
        public void RestorePlayerLayer()
        {
            if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            IInventoryItem item = other.GetComponent<IInventoryItem>();
            if (item != null)
            {
                HUD.publicinventory.AddItem(item);
            }
        }
        private void UseSomthing()
        {
            for (int count = 0; count < 4; count++)
            {
                if (Input.GetButtonDown("Item" + (count + 1)) && HUD.emptyBox[count] == false && GameController.canUseItems[count] != null)
                {
                    HUD.publicinventory.UseItem(GameController.canUseItems[count]);
                }
            }
        }
    }
}
