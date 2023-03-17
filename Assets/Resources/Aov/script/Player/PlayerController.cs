using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
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
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private Vector2 trans1;
    private bool isQrun = false;
    public static bool isLorR;
    private bool isGround;
    private bool canDoubleJump;
    private bool isOneWayPlatform;
    private PlayerInputActions controls;
   
    #region Gamepad
    //private Vector2 move;

    //void Awake()
    //{
    //    controls = new PlayerInputActions();
    //    controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    //    controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;
    //    controls.GamePlay.Jump.started += ctx => Jump();

    //}
    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}
    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}
    // Start is called before the first frame update
    #endregion
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameController.CurrentPlayer = gameObject;
        //if (gameObject.activeInHierarchy)
        //{
        //    BGM.playForestClip();
        //}

        trans1 = transform.position;
        if (GameController.isGameAlive == true&& GameController.isGameSaying == false&&PlayerHealth.isDie==false)
        {
            Run();
            Filp();
            Jump();
            CheckGrounded();
            SwitchAnimation();
            OneWayPlatformCheck();
            UseSomthing();
        }

        //判断是否快跑
        if (Input.GetButtonDown("Speed"))
        {
            isQrun = !isQrun;
        }
        //放技能后坐力
        if (SkillAttack.skilling)
        {
            if (isLorR == true)
            {
                trans1.x -= skillcounterforce;

            }
            else
            {
                trans1.x += skillcounterforce;
            }
            transform.position = trans1;
            SkillAttack.skilling = false;

        }
    }
    void CreateDust()
    {
        dust.Play();
    }
    #region Move
    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))||
             myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
             myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        isOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }
    void Filp()
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
    void Run()
    {
        float movedir;
        if (isQrun)
        //if (Input.GetKey(KeyCode.LeftShift))
        {
            movedir = Input.GetAxis("Horizontal") * 3;
        }
        else
        {
            movedir = Input.GetAxis("Horizontal");
        }
        if (Mathf.Abs(movedir) > 0.2f)
        {
            bgm.playbgm = true;
        }
        myAnim.SetFloat("runSpeed", Mathf.Abs(movedir));
        Vector2 playervel = new Vector2(movedir * runspeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playervel;
        bool playerhasxaxisspeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (isGround)
        {
            myAnim.SetBool("run", playerhasxaxisspeed);
            //Vector2 playerVel = new Vector2(move.x * runspeed, myRigidbody.velocity.y);
            //myRigidbody.velocity = playerVel;
            //bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            //myAnim.SetBool("run", playerHasXAxisSpeed);

        }
    }
    void Jump()
    {
        if (GameController.isGameAlive == true && GameController.isGameSaying == false)
            if (Input.GetButtonDown("Jump"))
            {
            if (isGround)
                {
                    CreateDust();
                    myAnim.SetBool("jump", true);
                    Vector2 JumpVel = new Vector2(0.0f, jumpspeed);
                    myRigidbody.velocity = Vector2.up * JumpVel;
                    canDoubleJump = true;
                }
            else
            {

                    myAnim.SetBool("run",false);
                    if (canDoubleJump&& myAnim.GetBool("idle")==false)
                    {
                        myAnim.SetBool("djump", true);
                        CreateDust();
                        Vector2 doubleJumpVel = new Vector2(0.0f,doublejumpspeed);
                        myRigidbody.velocity = Vector2.up * doubleJumpVel;
                        canDoubleJump = false;
                    }
            }
        }
    }
    //void attack()
    //{
    //    if (input.getbuttondown("attack"))
    //    {
    //        myanim.settrigger("sbattack");
    //    }
    //}
    void SwitchAnimation()
    {
        myAnim.SetBool("idle", false);
        if (myAnim.GetBool("jump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("jump", false);
                myAnim.SetBool("fall", true);
            }
        }
        else if(isGround)
        { 
            myAnim.SetBool("fall", false);
            myAnim.SetBool("idle", true);
        }
        if (myAnim.GetBool("djump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("djump", false);
                myAnim.SetBool("dfall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("dfall", false);
            myAnim.SetBool("idle", true);
        }
    }
    void OneWayPlatformCheck()
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
    void RestorePlayerLayer()
    {
        if(!isGround&& gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            HUD.publicinventory.AddItem(item);
        }
    }
    #region useItem
    private void UseSomthing()
    {
        for(int count = 0; count < 4; count++)
        {
            if (Input.GetButtonDown("Item"+(count+1)) && HUD.emptyBox[count] == false&&GameController.canUseItems[count]!=null)
            {
                HUD.publicinventory.UseItem(GameController.canUseItems[count]);
            }
        }
    }
    #endregion
    #region SoundManager Control
    void playerAttack1()
    {
        attack1.GetComponent<PolygonCollider2D>().enabled = true;
        SoundManager.playfirstAClip();
        Invoke("disAttack1", 0.1f);
    }
    void disAttack1()
    {
        attack1.GetComponent<PolygonCollider2D>().enabled = false;
    }
    void playerAttack2()
    {
        attack2.GetComponent<PolygonCollider2D>().enabled = true;
        SoundManager.playsecondAClip();
        Invoke("disAttack2", 0.1f);
    }
    void disAttack2()
    {
        attack2.GetComponent<PolygonCollider2D>().enabled = false;
    }
    void playerAttack3()
    {
        attack3.GetComponent<PolygonCollider2D>().enabled = true;
        SoundManager.playthirdAClip();
        Invoke("disAttack3", 0.1f);
    }
    void disAttack3()
    {
        attack3.GetComponent<PolygonCollider2D>().enabled = false;
    }
    #endregion
}
