using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMainMap : MonoBehaviour
{
    [SerializeField] DialogManager KaLinDialogManager;
    private void Start()
    {
        CheckNV5();
        
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
}
