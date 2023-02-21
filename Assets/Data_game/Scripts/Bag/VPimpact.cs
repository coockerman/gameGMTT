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
            t = PlayerPrefs.GetInt(gameObject.name);
            PlayerPrefs.SetInt(gameObject.name, t + 1);
            Destroy(gameObject);

        }
    }
    void HuyGameObject()
    {

    }
}
