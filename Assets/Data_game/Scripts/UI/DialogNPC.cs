using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public DialogManager dialogManager;
    public PlayerCtrl playerCtrl;
    public bool dialogActive;

    public string[] dialogNPC;
    public int[] listDialog;
    public int listIndex = 0;
    public int dialogIndex = 0;
    private void Awake()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        playerCtrl = FindObjectOfType<PlayerCtrl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        dialogActive = false;
    }
    // Update is called once per frame
    void Update()
    {
        SetActiveDialog();
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


