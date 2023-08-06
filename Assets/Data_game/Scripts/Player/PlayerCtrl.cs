using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] AudioSource audioPlayer;
    protected Rigidbody2D body;
    protected Animator anim;
    protected PlayerManaManager playerManaManager;
    [SerializeField] GameManager gameManager;
    protected float horizontal;
    protected float vertical;

    private static bool playerExitsts = false;

    //Danh thuong
    private bool attacking = false;
    private float attackTime;
    private float attackTimeCount;
    float TimeOffAttack;

    //Skill one
    private bool skillOnePlay = false;
    private float skillOneTime;
    private float skillOneTimeCount;
    float TimeOffSkillOne;

    //Skill two
    private bool skillTwoPlay = false;
    private float skillTwoTime;
    private float skillTwoTimeCount;
    float TimeOffSkillTwo;

    public float runSpeed;
    [SerializeField] protected float currentRunSpeed;
    [SerializeField] protected float diagonalMoveModifier = 0.75f;

    public string StartPoint;

    public bool moveActive = true;
    public bool moveActiveBag = true;
    public bool moveActiveMission = true;
    public bool moveActiveUpgradePower = true;
    public bool moveActiveUiSetting = true;
    public bool playerMoving;
    private Vector2 lastMove;
    void Start()
    {
        attackTime = 0.3f;
        skillOneTime = 0.6f;
        skillTwoTime = 0.7f;

        TimeOffAttack = 0.1f;
        TimeOffSkillOne = 0.6f;
        TimeOffSkillTwo = 0.7f;
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
        if (moveActive == true && moveActiveBag == true && moveActiveMission == true && moveActiveUpgradePower == true && moveActiveUiSetting == true && GameManager.playDialog == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if(horizontal != 0 || vertical != 0)
            {
                if(audioPlayer.isPlaying == false)
                {
                    audioPlayer.Play();
                }
            }
            else
            {
                audioPlayer.Pause();
            }
        }
        else
        {
            audioPlayer.Pause();
            horizontal = 0;
            vertical = 0;
        }

    }

    private void FixedUpdate()
    {
        this.LoadAttack();

        this.LoadSkillOne();
        this.LoadSkillTwo();

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
        if (moveActive == false || moveActiveBag == false || moveActiveMission == false || moveActiveUpgradePower == false || moveActiveUiSetting == false) return;
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
        }
        return;
    }
    protected virtual void Attack()
    {
        body.velocity = new Vector2(0, 0);
        anim.SetBool("Attack", true);
        Invoke("OffAttackThuong", TimeOffAttack);
        attacking = true;
    }
    void OffAttackThuong()
    {
        anim.SetBool("Attack", false);
    }
    protected virtual void LoadSkillOne()
    {
        if (moveActive == false || moveActiveBag == false || moveActiveMission == false || moveActiveUpgradePower == false || moveActiveUiSetting == false) return;
        if (Input.GetKeyDown(KeyCode.K) && playerManaManager.playerCurrentMana < 5)
        {
            playerManaManager.HetMana();
        }
        if (Input.GetKey(KeyCode.K) && skillOnePlay == false && playerManaManager.GetStatusSkill1() == true)
        {
            skillOneTimeCount = skillOneTime;
            SkillOne();
            playerManaManager.GiamMana(5);

        }
        if (skillOnePlay == false) return;
        skillOneTimeCount -= Time.fixedDeltaTime;
        if (skillOneTimeCount < 0)
        {
            skillOneTimeCount = skillOneTime;
            skillOnePlay = false;
        }
    }
    protected virtual void SkillOne()
    {

        body.velocity = new Vector2(0, 0);
        anim.SetBool("SkillOne", true);
        Invoke("OffSkillOne", TimeOffSkillOne);
        skillOnePlay = true;
    }
    void OffSkillOne()
    {
        anim.SetBool("SkillOne", false);
    }
    protected virtual void LoadSkillTwo()
    {
        if (moveActive == false || moveActiveBag == false || moveActiveMission == false || moveActiveUpgradePower == false || moveActiveUiSetting == false) return;
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
        }
    }
    protected virtual void SkillTwo()
    {

        body.velocity = new Vector2(0, 0);
        anim.SetBool("SkillTwo", true);
        Invoke("OffSkillTwo", TimeOffSkillTwo);
        skillTwoPlay = true;
    }
    void OffSkillTwo()
    {
        anim.SetBool("SkillTwo", false);

    }
    public void OffSkill()
    {
        anim.SetBool("SkillOne", false);
        anim.SetBool("SkillTwo", false);
        anim.SetBool("Attack", false);

    }

}
