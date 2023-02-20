using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManagerPlayer : UiManager
{
    public PlayerHearthManager HealthObject;
    public PlayerManaManager manaObject;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI ManaText;
    private static bool UiExits = false;

    // Start is called before the first frame update
    void Start()
    {
        HealthObject = FindObjectOfType<PlayerHearthManager>();
        manaObject= FindObjectOfType<PlayerManaManager>();
        healthBar.maxValue = HealthObject.playerMaxHealth;

        if (!UiExits)
        {
            UiExits = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        NowHealth();
        NowMana();
    }
    protected override void NowHealth()
    {
        healthBar.maxValue = HealthObject.playerMaxHealth;
        healthBar.value = HealthObject.playerCurrentHealth;
        HPText.text = "HP: " + HealthObject.playerCurrentHealth + "/" + HealthObject.playerMaxHealth;
    }
    protected override void NowMana()
    {
        manaBar.maxValue = manaObject.playerMaxMana;
        manaBar.value = manaObject.playerCurrentMana;
        ManaText.text = "KI: " + manaObject.playerCurrentMana + "/" + manaObject.playerMaxMana;
    }
}
