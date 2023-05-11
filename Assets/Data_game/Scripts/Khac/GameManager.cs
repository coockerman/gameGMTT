using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected float waitToReload = 2;
    private static bool gameManager = false;
    [SerializeField] PlayerCtrl Player;
    public bool playDialog;
    
    private void Start()
    {
        if(Player == null)
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
        if (Player.transform.gameObject.activeSelf == true) return;
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            waitToReload = 2;
            Player.transform.position = new Vector3(-1, 18, 0);
            Player.transform.gameObject.SetActive(true);

        }
    }

    
}
