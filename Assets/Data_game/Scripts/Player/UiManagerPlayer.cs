using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManagerPlayer : UiManager
{
    public PlayerHearthManager HealthObject;
    public TextMeshProUGUI HPText;

    private static bool UiExits = false;

    // Start is called before the first frame update
    void Start()
    {
        HealthObject = FindObjectOfType<PlayerHearthManager>();
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
    }
    protected override void NowHealth()
    {
        healthBar.maxValue = HealthObject.playerMaxHealth;
        healthBar.value = HealthObject.playerCurrentHealth;
        HPText.text = "HP: " + HealthObject.playerCurrentHealth + "/" + HealthObject.playerMaxHealth;
    }
}
