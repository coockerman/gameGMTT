using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingNumberPlayer : FloatingNumber
{
    public PlayerHearthManager damageInPlayer;

    // Start is called before the first frame update
    void Start()
    {
        damageInPlayer = FindObjectOfType<PlayerHearthManager>();
        damageNumber = damageInPlayer.MatDame;
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = "" + damageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, 0);
    }
}
