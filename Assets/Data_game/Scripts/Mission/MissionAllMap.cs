using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissionAllMap : MonoBehaviour
{
    private void Start()
    {
        CheckDialogs();
    }

    protected virtual void CheckDialogs()
    {

    }
    protected virtual void CheckDialog(int nvNow, DialogManager dialogManager, int sl)
    {
        if (DataCheckNV.NVnow >= nvNow)
        {
            for (int i = 0; i < sl; i++)
            {
                dialogManager.AddDialog();
            }
        }
    }
}
