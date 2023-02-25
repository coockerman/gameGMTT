using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV3_OpenStore : MonoBehaviour
{
    public GameObject store;
    public virtual void NV3PickUpApple()
    {
        if (PlayerPrefs.GetInt("MissionMng") >= 3)
        {
            if (PlayerPrefs.GetInt("MissionMng") >= 4)
            {
                OpenStore();
                return;
            }
            if (PlayerPrefs.GetInt("dialogIndexBrum") >= 15)
            {
                OpenStore();
                PlayerPrefs.SetInt("MissionMng", 4);
            }
            
        }
    }
    protected virtual void OpenStore()
    {
        store.SetActive(true);
    }

}
