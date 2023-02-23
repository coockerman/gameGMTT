using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV3_PickUpApple : NV2_FarmVP
{
    [Header("NV3: PickUpApple")]
    public GameObject placeUpgrade;

    protected override void Update()
    {
        base.Update();
        NV3PickUpApple();
    }
    protected virtual void NV3PickUpApple()
    {
        if (PlayerPrefs.GetInt("MissionMng") >= 3)
        {
            if (PlayerPrefs.GetInt("VatPham2") >= 1)
            {
                OpenPlaceUpgrade();
                PlayerPrefs.SetInt("MissionMng", 4);
            }
            if(PlayerPrefs.GetInt("MissionMng") >= 4)
            {
                OpenPlaceUpgrade();
            }
        }
    }
    protected virtual void OpenPlaceUpgrade()
    {
        placeUpgrade.SetActive(true);

    }

}
