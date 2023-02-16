using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public string leverToload;

    public string ExitMap;

    private PlayerCtrl thePlayer;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerCtrl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Application.LoadLevel(leverToload);
            thePlayer.StartPoint = ExitMap;
        }
    }
}
