using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPowwer : MonoBehaviour
{
    public GameObject ImageUpgradePower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("UpgradePowerBox") == 1)
        {
            ImageUpgradePower.SetActive(true);
        }
    }
}
