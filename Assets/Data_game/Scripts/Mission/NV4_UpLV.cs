using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NV4_UpLV : MonoBehaviour
{
    public virtual void NV4UpLV()
    {
        if (PlayerPrefs.GetInt("MissionMng") >= 4)
        {
            if (PlayerPrefs.GetInt("MissionMng") >= 5)
            {
                //OpenStore();
                return;
            }
            if (PlayerPrefs.GetInt("playerLV") >= 4 && PlayerPrefs.GetInt("dialogIndexMai") >= 9)
            {
                //OpenStore();
                PlayerPrefs.SetInt("MissionMng", 5);
            }

        }
    }
}