using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHouseOnMountain2 : MonoBehaviour
{
    [SerializeField] DialogManager AnTromDialogManager;

    // Start is called before the first frame update
    void Start()
    {
        CheckNV8();
    }

    void CheckNV8()
    {
        if (PlayerPrefs.GetInt("NV8Check") == 1)
        {
            AnTromDialogManager.AddDialog();
            PlayerPrefs.SetInt("NV8Check", 0);
        }
    }
}
