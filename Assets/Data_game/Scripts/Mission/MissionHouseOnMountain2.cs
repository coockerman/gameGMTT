using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHouseOnMountain2 : MissionAllMap
{
    [SerializeField] DialogManager AnTromDialogManager;

    protected override void CheckDialogs()
    {
        CheckDialog(8, AnTromDialogManager, 1);
    }
    
}
