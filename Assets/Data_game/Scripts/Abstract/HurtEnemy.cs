using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class HurtEnemy : MonoBehaviour
{
    public float damageToGive;
    public GameObject damageBurst;
    public GameObject damageNumber;
    public PlayerAttackManager playerAttack;
    
    protected virtual void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttackManager>();
        
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);

            Instantiate(damageBurst, collision.transform.position, collision.transform.rotation);
            Instantiate(damageNumber, collision.transform.position, collision.transform.rotation);
        }
    }
    public virtual void Update()
    {
        

    }
    protected virtual float SetDame(float HeSo)
    {
        float damage = HeSo * playerAttack.damageToGive;
        return damage;
    }


}
