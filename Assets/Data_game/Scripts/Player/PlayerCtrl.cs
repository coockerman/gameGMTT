using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    protected Rigidbody2D body;
    private Animator anim;
    protected PlayerManaManager playerManaManager;

    protected float horizontal;
    protected float vertical;

    private static bool playerExitsts = false;

    //Danh thuong
    private bool attacking = false;
    private float attackTime;
    private float attackTimeCount;

    //Skill one
    private bool skillOnePlay = false;
    private float skillOneTime;
    private float skillOneTimeCount;

    //Skill two
    private bool skillTwoPlay = false;
    private float skillTwoTime;
    private float skillTwoTimeCount;

    [SerializeField] protected float runSpeed = 2.0f;
    [SerializeField] protected float currentRunSpeed;
    [SerializeField] protected float diagonalMoveModifier = 0.75f;

    public string StartPoint;

    public bool moveActive = true;
    public bool moveActiveBag = true;
    public bool moveActiveMission = true;
    public bool playerMoving;
    private Vector2 lastMove;
    void Start()
    {
        attackTime = 0.25f;
        skillOneTime = 0.6f;
        skillTwoTime = 0.6f;

        playerManaManager = GetComponent<PlayerManaManager>();

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (!playerExitsts)
        {
            playerExitsts = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        GetInput();
    }
    public void GetInput()
    {
        if (moveActive == true && moveActiveBag == true && moveActiveMission == true)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            horizontal = 0;
            vertical = 0;
        }

    }

    private void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("dialogIndexBon")>=13)
        {
            this.LoadAttack();

            this.LoadSkillOne();
            this.LoadSkillTwo();
        }
        
        if (attacking == true || skillOnePlay == true || skillTwoPlay == true) return;
        this.GetMoving();
        this.SetMoveInAnim();
        this.SetPosition();
    }

    protected virtual void SetMoveInAnim()
    {
        anim.SetFloat("MoveX", horizontal);
        anim.SetFloat("MoveY", vertical);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }
    protected virtual void GetMoving()
    {
        playerMoving = false;
        if (horizontal > 0.5f || horizontal < -0.5f || vertical > 0.5f || vertical < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(horizontal, vertical);
        }
    }

    protected virtual void SetSpeedPlayer()
    {
        if (Mathf.Abs(horizontal) > 0 && Mathf.Abs(vertical) > 0) currentRunSpeed = runSpeed * diagonalMoveModifier;
        else currentRunSpeed = runSpeed;
    }

    protected virtual void SetPosition()
    {
        this.SetSpeedPlayer();
        body.velocity = new Vector2(horizontal * currentRunSpeed, vertical * currentRunSpeed);
    }

    protected virtual void LoadAttack()
    {
        
        if (moveActive == false || moveActiveBag == false || moveActiveMission == false) return;
        if (Input.GetKey(KeyCode.J) && attacking == false)
        {
            attackTimeCount = attackTime;
            Attack();
        }
        if (attacking == false) return;
        attackTimeCount -= Time.fixedDeltaTime;
        if (attackTimeCount < 0)
        {
            attackTimeCount = attackTime;
            attacking = false;
            anim.SetBool("Attack", false);
        }
        return;
    }
    protected virtual void Attack()
    {
        body.velocity = new Vector2(0, 0);
        anim.SetBool("Attack", true);
        attacking = true;
    }
    protected virtual void LoadSkillOne()
    {
        if (moveActive == false || moveActiveBag == false || moveActiveMission == false) return;
        if (Input.GetKeyDown(KeyCode.K) && playerManaManager.playerCurrentMana < 10)
        {
            playerManaManager.HetMana();
        }
        if (Input.GetKey(KeyCode.K) && skillOnePlay == false && playerManaManager.GetStatusSkill1() == true)
        {
            skillOneTimeCount = skillOneTime;
            SkillOne();
            playerManaManager.GiamMana(10);

        }
        if (skillOnePlay == false) return;
        skillOneTimeCount -= Time.fixedDeltaTime;
        if (skillOneTimeCount < 0)
        {
            skillOneTimeCount = skillOneTime;
            skillOnePlay = false;
            anim.SetBool("SkillOne", false);
        }
    }
    protected virtual void SkillOne()
    {

        body.velocity = new Vector2(0, 0);
        anim.SetBool("SkillOne", true);
        skillOnePlay = true;
    }

    protected virtual void LoadSkillTwo()
    {
        if (moveActive == false || moveActiveBag == false || moveActiveMission == false) return;
        if (Input.GetKeyDown(KeyCode.L) && playerManaManager.GetStatusSkill2() == false)
        {
            playerManaManager.HetMana();
        }
        if (Input.GetKey(KeyCode.L) && skillTwoPlay == false && playerManaManager.GetStatusSkill2() == true)
        {
            skillTwoTimeCount = skillTwoTime;
            SkillTwo();
            playerManaManager.GiamMana(20);
        }
        if (skillTwoPlay == false) return;
        skillTwoTimeCount -= Time.fixedDeltaTime;
        if (skillTwoTimeCount < 0)
        {
            skillTwoTimeCount = skillTwoTime;
            skillTwoPlay = false;
            anim.SetBool("SkillTwo", false);
        }
    }
    protected virtual void SkillTwo()
    {

        body.velocity = new Vector2(0, 0);
        anim.SetBool("SkillTwo", true);
        skillTwoPlay = true;
    }


}
