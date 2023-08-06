using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMainMap : MissionAllMap
{
    [SerializeField] DialogManager BonDialogManager;
    [SerializeField] DialogManager KaLinDialogManager;
    
    protected override void CheckDialogs()
    {
        CheckDialog(5, KaLinDialogManager, 3);
        CheckDialog(10, BonDialogManager, 3);
    }
    
    
}
