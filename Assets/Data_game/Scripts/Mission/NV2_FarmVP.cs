using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV2_FarmVP : NV1_OpenEntry
{
    [Header("NV2: FarmVP")]
    public GameObject store;
    
    protected override void Update()
    {
        base.Update();
        NV2FarmVP();
    }
    protected virtual void NV2FarmVP()
    {
        if(PlayerPrefs.GetInt("MissionMng")>=2)
        {
            if (PlayerPrefs.GetInt("VatPham1") >= 2)
            {
                OpenStore();
                PlayerPrefs.SetInt("MissionMng", 3);

            }
            if (PlayerPrefs.GetInt("MissionMng") >= 3)
            {
                OpenStore();
            }
        }
    }
    protected virtual void OpenStore()
    {
        store.SetActive(true);
    }
}
