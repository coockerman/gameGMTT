using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHouseOnMountain1 : MissionAllMap
{

    [SerializeField] DialogManager brumDialogManager;
    [SerializeField] DialogManager atanDialogManager;
    
    protected override void CheckDialogs()
    {
        CheckDialog(2, brumDialogManager,1);
        CheckDialog(4, brumDialogManager, 1);
        CheckDialog(7, atanDialogManager, 1);
        CheckDialog(9, atanDialogManager, 1);
        CheckDialog(12, atanDialogManager, 1);
    }

    
    
}
