using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public int leverToload;

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
            SceneManager.LoadScene(leverToload);
            thePlayer.StartPoint = ExitMap;
        }
    }
}
