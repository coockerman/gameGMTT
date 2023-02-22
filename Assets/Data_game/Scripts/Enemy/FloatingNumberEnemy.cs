using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingNumberEnemy : FloatingNumber
{
    public HurtEnemy damageInEnemy;

    // Start is called before the first frame update
    void Start()
    {
        damageInEnemy = FindObjectOfType<HurtEnemy>();
        damageNumber = damageInEnemy.damageToGive;
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = "" + damageNumber;
    }
}
