using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV2_FarmVP : MonoBehaviour
{
    
    public virtual void NV2FarmVP()
    {      
        if (PlayerPrefs.GetInt("MissionMng")>=2 )
        {
            if (PlayerPrefs.GetInt("MissionMng") >= 3)
            {
                //OpenStore();
                return;
            }
            if (PlayerPrefs.GetInt("VatPham1") >= 3 && PlayerPrefs.GetInt("dialogIndexBrum") >= 7)
            {
                //OpenStore();
                PlayerPrefs.SetInt("MissionMng", 3);
            }
            
        }
    }
    
}
