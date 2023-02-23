using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NV1_OpenEntry : MonoBehaviour
{
    [Header("NV1: OpenEntry")]
    public GameObject entryObject;
    
    protected virtual void Update()
    {
        OpenEntryy();

    }
    protected virtual void OpenEntryy()
    {      
        if (PlayerPrefs.GetInt("dialogIndexBon") >= 13 && PlayerPrefs.GetInt("playerLV") >= 2)
        {
            OpenEntry();
            PlayerPrefs.SetInt("MissionMng", 2);
        }
        if(PlayerPrefs.GetInt("MissionMng") >=2)
        {
            OpenEntry();
        }
    }
    protected virtual void OpenEntry()
    {
        entryObject.SetActive(true);

    }
}
