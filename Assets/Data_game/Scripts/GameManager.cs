using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        HoiSinh();
    }
    protected virtual void HoiSinh()
    {
        if (Player.transform.gameObject.active == true) return;
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            waitToReload = 2;
            SceneManager.LoadScene(SceneManager.sceneCount - 1);
            Player.transform.gameObject.SetActive(true);

        }
    }

    
}
