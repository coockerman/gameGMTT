using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV2_FarmVP : MonoBehaviour
{
    [Header("NV2: FarmVP")]
    public GameObject store;
    
    
    public virtual void NV2FarmVP()
    {      
        if (PlayerPrefs.GetInt("MissionMng")>=2)
        {
            if (PlayerPrefs.GetInt("MissionMng") >= 3)
            {
                OpenStore();
                return;
            }
            if (PlayerPrefs.GetInt("VatPham1") >= 2)
            {
                OpenStore();
                PlayerPrefs.SetInt("MissionMng", 3);

            }
            
        }
    }
    protected virtual void OpenStore()
    {
        store.SetActive(true);
    }
}
