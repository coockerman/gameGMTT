using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public DialogManager dialogManager;
    public bool dialogActive;

    public string[] dialogNPC;
    public int[] indexDialog;
    public int dialogIndex;
    // Start is called before the first frame update
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        dialogIndex = 0;
        dialogActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        addDialog();
        SetActiveDialog();
        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.R))
        {
            dialogActive = true;
            dialogManager.OnBox();
            

        }
    }
    protected virtual void addDialog()
    {
        dialogManager.dialogText = dialogNPC[dialogIndex];

    }
    void SetActiveDialog()
    {
        
        if (dialogIndex >= dialogNPC.Length-1)
        {
            dialogActive = false;
            dialogIndex = 0;

            dialogManager.CloseBox();
            return;
        }
        
        if (dialogActive == true && Input.GetKeyUp(KeyCode.R))
        {
            if (dialogIndex >= dialogNPC.Length-1) return;
            dialogIndex++;       
        }
        
        
    }

}
