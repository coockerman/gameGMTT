using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMainMap : MonoBehaviour
{
    [SerializeField] DialogManager BonDialogManager;
    [SerializeField] DialogManager KaLinDialogManager;
    private void Start()
    {
        CheckNV5();
        CheckNV10();
    }

    void CheckNV5()
    {
        if (PlayerPrefs.GetInt("NV5Check") == 1)
        {
            KaLinDialogManager.AddDialog();
            KaLinDialogManager.AddDialog();
            KaLinDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV5Check", 0);
        }
    }
    void CheckNV10()
    {
        if (PlayerPrefs.GetInt("NV10Check") == 1)
        {
            BonDialogManager.AddDialog();
            BonDialogManager.AddDialog();
            BonDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV10Check", 0);
        }
    }
}
