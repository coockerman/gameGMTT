using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPlayer : MonoBehaviour
{
    protected int ManaBuff;
    protected PlayerManaManager playerMana;
    private void Awake()
    {
        playerMana = FindObjectOfType<PlayerManaManager>();
    }
    private void Start()
    {
        ManaBuff = 60;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMana.HoiMana(ManaBuff);
            Destroy(gameObject);
        }
    }
}
