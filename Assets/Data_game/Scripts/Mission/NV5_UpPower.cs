using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV5_UpPower : MonoBehaviour
{
    
    private void Update()
    {
        NV5UpPower();
    }
    public virtual void NV5UpPower()
    {
        if (PlayerPrefs.GetInt("MissionMng") >= 5)
        {
            if (PlayerPrefs.GetInt("MissionMng") >= 6)
            {
                OpenMissionImage();
                return;
            }
            if (PlayerPrefs.GetInt("dialogIndexAtan") >= 6 && PlayerPrefs.GetInt("dialogIndexAnTrom")>=2);
            {
                OpenMissionImage();
                PlayerPrefs.SetInt("MissionMng", 6);
            }

        }
    }
    public void OpenMissionImage()
    {
        PlayerPrefs.SetInt("UpgradePowerBox", 1);
    }
}
