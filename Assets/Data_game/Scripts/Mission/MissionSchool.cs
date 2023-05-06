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
}
