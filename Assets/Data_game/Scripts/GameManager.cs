using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected float waitToReload = 2;
    private static bool gameManager = false;
    public PlayerCtrl Player;
    private void Start()
    {
        Player = FindObjectOfType<PlayerCtrl>();
        if (!gameManager)
        {
            gameManager = true;
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
        if (Player.transform.gameObject.active == true) return;
        waitToReload -= Time.deltaTime;
        if(waitToReload < 0)
        {
            waitToReload = 2;
            Application.LoadLevel(Application.loadedLevel);
            Player.transform.gameObject.SetActive(true);

        }
    }
}
