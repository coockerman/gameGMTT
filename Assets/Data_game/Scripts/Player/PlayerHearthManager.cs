using UnityEngine;

public class PlayerHearthManager : MonoBehaviour
{
    public static PlayerHearthManager instance;
    PlayerCtrl playerCtrl;
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip danh;
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int MatDame;

    private bool flashActive = false;
    private int flashCount = 2;
    private int flashSize = 1;

    public bool BatTu = false;
    public bool BatTu2 = false;

    private float TimeNow = 0;
    private float TimeFlash = 0.25f;
    private SpriteRenderer playerSprite;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        playerSprite = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("playerHearth") == 0)
            PlayerPrefs.SetInt("playerHearth", playerMaxHealth);
        playerMaxHealth = PlayerPrefs.GetInt("playerHearth");
        SetMaxHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            playerCtrl.OffSkill();
            Invoke("Died", 0.8f);
        }
        if (BatTu2 == true)
        {
            SetOnColor();
            return;
        }
        GetFlashActive();
    }
    void Died()
    {
        gameObject.SetActive(false);
        SetMaxHealth();
    }
    private void GetFlashActive()
    {
        if (flashActive == false) SetOnColor();
        if (flashActive == true) SetOffColor();
    }

    private void SetOnColor()
    {
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 255f);
        if (flashCount >= flashSize)
        {
            BatTu = false;
            return;
        }
        TimeNow += Time.deltaTime;
        if (TimeNow >= TimeFlash)
        {
            flashActive = true;
            TimeNow = 0;
        }
    }
    private void SetOffColor()
    {
        BatTu = true;
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
        TimeNow += Time.deltaTime;
        if (TimeNow >= TimeFlash)
        {
            flashCount++;
            flashActive = false;
            TimeNow = 0;
        }
    }
    public void HurtPlayer(int damageToGive)
    {
        audioPlayer.PlayOneShot(danh);
        MatDame = damageToGive;
        playerCurrentHealth -= damageToGive;
        if (playerCurrentHealth < 0)
        {
            playerCurrentHealth = 0;
        }
        flashActive = true;
        flashCount = 0;
    }
    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void UpHp(int UpHp)
    {
        playerCurrentHealth += UpHp;
        playerMaxHealth += UpHp;
        PlayerPrefs.SetInt("playerHearth", playerMaxHealth);

    }
    public void HoiHp(int hoiHp)
    {
        playerCurrentHealth += hoiHp;
        if (playerCurrentHealth > playerMaxHealth)
            SetMaxHealth();
    }
}
