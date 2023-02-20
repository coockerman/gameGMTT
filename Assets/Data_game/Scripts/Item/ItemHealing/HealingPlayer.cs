using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlayer : MonoBehaviour
{
    protected int healing;
    protected PlayerHearthManager playerHearth;
    private void Awake()
    {
        playerHearth = FindObjectOfType<PlayerHearthManager>();
    }
    private void Start()
    {
        healing = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHearth.playerCurrentHealth = playerHearth.playerCurrentHealth + healing;
            if(playerHearth.playerCurrentHealth > playerHearth.playerMaxHealth)
            {
                playerHearth.playerCurrentHealth = playerHearth.playerMaxHealth;
            }
            Destroy(gameObject);
        }
    }
}
