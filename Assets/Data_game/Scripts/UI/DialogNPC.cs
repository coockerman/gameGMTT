using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    protected string SAVE_1 = "";
    protected string SAVE_2 = "";

    public DialogManager dialogManager;
    public PlayerCtrl playerCtrl;
    public bool dialogActive;
    public string nameNPC;

    public string[] dialogNPC;
    public int[] listDialog;
    public int listIndex = 0;
    public int dialogIndex = 0;
    private void Awake()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        playerCtrl = FindObjectOfType<PlayerCtrl>();
        LoadStringSave();
    }
    // Start is called before the first frame update
    void Start()
    {
        listIndex = PlayerPrefs.GetInt(SAVE_1);
        dialogIndex = PlayerPrefs.GetInt(SAVE_2);
        dialogActive = false;
        for(int i =0; i<dialogNPC.Length; i++)
        {
            dialogNPC[i] = nameNPC + ": " + dialogNPC[i];
        }
    }
    // Update is called once per frame
    void Update()
    {
        SetActiveDialog();
        //SetData();
    }
    protected virtual void LoadStringSave()
    {
        SAVE_1 = "listIndex" + gameObject.name;
        SAVE_2 = "dialogIndex" + gameObject.name;
    }
    protected virtual void SetData()
    {
        PlayerPrefs.SetInt(SAVE_1, listIndex);
        PlayerPrefs.SetInt(SAVE_2, dialogIndex);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.R))
        {
            dialogActive = true;
            dialogManager.OnBox();
            dialogIndex = listDialog[listIndex] - 1;
            playerCtrl.moveActive = false;
        }
    }

    void SetActiveDialog()
    {

        if (dialogIndex >= listDialog[listIndex + 1] || dialogIndex >= dialogNPC.Length)
        {
            //dialogIndex = 0;
            if (dialogIndex >= dialogNPC.Length) --listIndex;

            listIndex++;
            SetData();
            dialogActive = false;
            playerCtrl.moveActive = true;
            dialogManager.CloseBox();
            return;
        }

        if (dialogActive == true && Input.GetKeyDown(KeyCode.R))
        {
            dialogIndex++;
            if (dialogIndex >= listDialog[listIndex + 1] || dialogIndex < 0 || dialogIndex >= dialogNPC.Length) return;
            addDialog();
        }
    }
    protected virtual void addDialog()
    {
        dialogManager.dialogText = dialogNPC[dialogIndex];

    }
}


