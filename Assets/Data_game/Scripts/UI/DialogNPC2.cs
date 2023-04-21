using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogNPC2 : MonoBehaviour
{
    [SerializeField] string nameDialog;
    [SerializeField] string[] dataDialog;
    GameManager gameManager;
    DialogManager dialogManager;
    [SerializeField] TextMeshProUGUI dialogText;

    int countDialog;
    private void OnEnable()
    {
        countDialog = 0;
        //dialogText = GetComponentInChildren<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
        dialogManager = GameObject.Find(nameDialog).GetComponent<DialogManager>();
        dialogText.text = dataDialog[countDialog];
        gameManager.playDialog = true;
    }

    private void Update()
    {
        NextDialog();
    }
    void NextDialog()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            if(countDialog < dataDialog.Length-1)
            {
                countDialog++;
                dialogText.text = dataDialog[countDialog];
            }
            else
            {
                string DATAFinaly = "" + nameDialog;
                PlayerPrefs.SetInt(DATAFinaly, 1);
                gameManager.playDialog = false;
                Destroy(gameObject);
            }
        }
    }
}
