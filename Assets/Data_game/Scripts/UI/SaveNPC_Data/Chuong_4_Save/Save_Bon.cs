using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Save_Bon : SaveNPC
{
    protected override void LoadStringSave()
    {
        SAVE_1 = "listIndex_Bon";
        SAVE_2 = "dialogIndex_Bon";
    }
}
