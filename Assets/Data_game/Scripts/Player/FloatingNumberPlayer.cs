using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingNumberPlayer : FloatingNumber
{
    public HurtPlayer damageInPlayer;

    // Start is called before the first frame update
    void Start()
    {
        damageInPlayer = FindObjectOfType<HurtPlayer>();
        damageNumber = damageInPlayer.damageToGive;
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = "" + damageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, 0);
    }
}
