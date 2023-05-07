using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class HurtEnemy : MonoBehaviour
{
    [SerializeField] protected AudioSource audioPlayer;
    [SerializeField] GameObject damageBurst;
    [SerializeField] GameObject damageNumber;
    [SerializeField] PlayerAttackManager playerAttack;
    [SerializeField] float TiLeDame;

    public float damageToGive;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            damageToGive = SetDame(TiLeDame);
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy((int)damageToGive);
            Instantiate(damageBurst, collision.transform.position, collision.transform.rotation);
            Instantiate(damageNumber, collision.transform.position, collision.transform.rotation);
            OnShot();
        }
    }
    protected virtual void OnShot()
    {
        //
    }
    protected virtual float SetDame(float HeSo)
    {
        float damage = HeSo * playerAttack.damageToGive;
        return damage;
    }


}
