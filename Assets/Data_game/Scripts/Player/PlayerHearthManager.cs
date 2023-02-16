using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool flashActive = false;
    private int flashCount = 3;
    private int flashSize = 3;

    public bool BatTu = false;

    private float TimeNow = 0;
    private float TimeFlash = 0.3f;
    private SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            SetMaxHealth();
        }
        GetFlashActive();
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
        playerCurrentHealth -= damageToGive;
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
    }
}
