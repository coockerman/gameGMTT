using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Brum : SaveNPC
{
    protected override void LoadStringSave()
    {
        SAVE_1 = "listIndex_Brum";
        SAVE_2 = "dialogIndex_Brum";
    }
}
