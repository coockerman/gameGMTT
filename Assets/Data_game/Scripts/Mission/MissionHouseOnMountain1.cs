using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHouseOnMountain1 : MonoBehaviour
{

    [SerializeField] DialogManager brumDialogManager;
    [SerializeField] DialogManager atanDialogManager;
    private void Start()
    {
        CheckDialogs();
    }
    
    private void CheckDialogs()
    {
        CheckDialog(2, brumDialogManager,1);
        CheckDialog(4, brumDialogManager, 1);
        CheckDialog(7, atanDialogManager, 1);
        CheckDialog(9, atanDialogManager, 1);
        CheckDialog(12, atanDialogManager, 1);
    }

    private void CheckDialog(int nvNow, DialogManager dialogManager, int sl)
    {
        if (DataCheckNV.NVnow >= nvNow)
        {
            for(int i = 0; i < sl; i++)
            {
                dialogManager.AddDialog();
            }
        }
    }
    
}
