using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageNumber;
    public PlayerHearthManager playerHearth;

    private void Start()
    {
        playerHearth= FindObjectOfType<PlayerHearthManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && playerHearth.BatTu == false)
        {
            collision.gameObject.GetComponent<PlayerHearthManager>().HurtPlayer(damageToGive);

            Instantiate(damageNumber, collision.transform.position, collision.transform.rotation);

        }

    }
}
