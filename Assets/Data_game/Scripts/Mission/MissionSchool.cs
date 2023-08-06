using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSchool : MissionAllMap
{
    [SerializeField] DialogManager DenyDialogManager;

    protected override void CheckDialogs()
    {
        CheckDialog(14, DenyDialogManager, 4);
        CheckDialog(16, DenyDialogManager, 1);
    }

}
