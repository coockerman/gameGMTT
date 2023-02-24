using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV3_PickUpApple : MonoBehaviour
{

    public virtual void NV3PickUpApple()
    {
        if (PlayerPrefs.GetInt("MissionMng") >= 3)
        {
            if (PlayerPrefs.GetInt("MissionMng") >= 4)
            {
                OpenPlaceUpgrade();
                return;
            }
            if (PlayerPrefs.GetInt("VatPham2") >= 1)
            {
                OpenPlaceUpgrade();
                PlayerPrefs.SetInt("MissionMng", 4);
            }
            
        }
    }
    protected virtual void OpenPlaceUpgrade()
    {
        PlayerPrefs.SetInt("UpgradePowerBox", 1);
    }

}
