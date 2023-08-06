using UnityEngine;

public class KeyMoveInMap : MonoBehaviour
{
    [SerializeField] int lv;
    [SerializeField] Transform endMove;
    [SerializeField] Transform player;
    bool hasImpact;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            hasImpact = true;
        }
        else
        {
            hasImpact = false;
        }
    }
    private void Update()
    {
        if(hasImpact)
        {
            int lvNow = PlayerPrefs.GetInt("playerLV");
            if(lvNow >= lv && Input.GetKeyDown(KeyCode.V))
            {
                if(player != null)
                {
                    player = FindObjectOfType<PlayerCtrl>().transform;
                    player.position = endMove.position;
                    hasImpact = false;
                }
            }
        }
    }
}

