using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageNumber;
    public PlayerHearthManager playerHearth;

    [Header("1: Tang cap so cong, 2:Tang theo ti le phan tram")]
    [SerializeField] int LoaiTangDame;
    [SerializeField] float TangDameMacDinh;
    [SerializeField] float CongSai;
    [SerializeField] float TangDamePhanTram;
    [SerializeField]EnemyHealthManager enemyHealth;
    string SavelvEnemy;
    float TangDame;
    private void Awake()
    {
        playerHearth= FindObjectOfType<PlayerHearthManager>();
        if(enemyHealth == null)
        enemyHealth = GetComponent<EnemyHealthManager>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && playerHearth.BatTu == false && playerHearth.BatTu2 == false)
        {
            SetTangDame();
            collision.gameObject.GetComponent<PlayerHearthManager>().HurtPlayer(damageToGive + (int)TangDame);
            Instantiate(damageNumber, collision.transform.position, collision.transform.rotation);
        }
    }

    void SetTangDame()
    {
        SavelvEnemy = enemyHealth.EnemyLV_NAME;
        int lvEnemy = PlayerPrefs.GetInt(SavelvEnemy);
        if (LoaiTangDame == 1)
        {
            TangDame = (lvEnemy - 1)*(TangDameMacDinh + CongSai * (lvEnemy - 1));
        }
        else if (LoaiTangDame == 2)
        {
            TangDame = damageToGive * (Mathf.Pow((1 + TangDamePhanTram / 100), (lvEnemy - 1)) - 1);
        }
        else
        {
            TangDame = 0;
        }
    }
}
