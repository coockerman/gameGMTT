using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHouseOnMountain1 : MonoBehaviour
{
    [SerializeField] DialogManager BrumDialogManager;
    [SerializeField] DialogManager AtanDialogManager;
    private void Start()
    {
        CheckNV2();
        CheckNV4();
        CheckNV7();
        CheckNV9();
    }
    void CheckNV2()
    {
        if(PlayerPrefs.GetInt("NV2Check") == 1)
        {
            BrumDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV2Check", 0);

        }
    }
    void CheckNV4()
    {
        if (PlayerPrefs.GetInt("NV4Check") == 1)
        {
            BrumDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV4Check", 0);
        }
    }
    void CheckNV7()
    {

        if (PlayerPrefs.GetInt("NV7Check") == 1)
        {
            AtanDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV7Check", 0);
        }
    }
    
    void CheckNV9()
    {
        if (PlayerPrefs.GetInt("NV9Check") == 1)
        {
            AtanDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV9Check", 0);
        }
    }
}
