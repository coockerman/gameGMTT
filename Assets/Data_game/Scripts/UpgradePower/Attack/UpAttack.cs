using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAttack : MonoBehaviour
{
    public PlayerAttackManager PlayerAttack;
    private int TangDame;
    private void Awake()
    {
        PlayerAttack= GetComponent<PlayerAttackManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        TangDame = 1;
    }

    public void UpMoreDame()
    {
        Debug.Log("a");
        PlayerAttack.UpDamage(TangDame);
        
    }
}
