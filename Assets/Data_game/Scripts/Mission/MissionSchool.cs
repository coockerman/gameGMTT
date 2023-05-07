using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSchool : MonoBehaviour
{
    [SerializeField] DialogManager DenyDialogManager;

    // Start is called before the first frame update
    void Start()
    {
        CheckNV14();
        CheckNV16();
    }

    void CheckNV14()
    {
        if (PlayerPrefs.GetInt("NV14Check") == 1)
        {
            DenyDialogManager.AddDialog();
            DenyDialogManager.AddDialog();
            DenyDialogManager.AddDialog();
            DenyDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV14Check", 0);
        }
    }
    void CheckNV16()
    {
        if (PlayerPrefs.GetInt("NV16Check") == 1)
        {
            DenyDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV16Check", 0);
        }
    }
}
