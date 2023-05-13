using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiExp : MonoBehaviour
{
    public TextMeshProUGUI LvText;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        //playerStats = FindObjectOfType<PlayerStats>();
        LvText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    

    
}
