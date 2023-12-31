using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] protected int healing;

    protected PlayerHearthManager playerHearth;

    private void Awake()
    {
        playerHearth = FindObjectOfType<PlayerHearthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            playerHearth.HoiHp(healing);
            Destroy(gameObject);
        }
    }
}
