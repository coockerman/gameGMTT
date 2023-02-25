using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPimpact : MonoBehaviour
{
    
    protected int t;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt(gameObject.name, PlayerPrefs.GetInt(gameObject.name) + 1);
            Destroy(gameObject);

        }
    }
    void HuyObject()
    {
        
    }
    
}
