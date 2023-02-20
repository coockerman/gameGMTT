using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveNPC : MonoBehaviour
{
    protected string SAVE_1 = "";
    protected string SAVE_2 = "";
    protected DialogNPC dialogNPC;

    protected virtual void Awake()
    {
        //PlayerPrefs.DeleteAll();
        LoadStringSave();
    }
    protected abstract void LoadStringSave();
    private void Start()
    {
        dialogNPC = GetComponent<DialogNPC>();

        dialogNPC.listIndex = PlayerPrefs.GetInt(SAVE_1);
        dialogNPC.dialogIndex = PlayerPrefs.GetInt(SAVE_2);
    }

    private void FixedUpdate()
    {
        PlayerPrefs.SetInt(SAVE_1, dialogNPC.listIndex);
        PlayerPrefs.SetInt(SAVE_2, dialogNPC.dialogIndex);
        //if (dialogNPC.dialogActive == true)
        //{
            
        //}
    }
}
