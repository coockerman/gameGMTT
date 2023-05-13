using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogNPC2 : MonoBehaviour
{
    [SerializeField] string nameDialog;
    [SerializeField] string addressDialog;
    [SerializeField] string[] dataDialog;
    [SerializeField] TextMeshProUGUI dialogText;
    bool isEndDialog;
    int countDialog;
    private void OnEnable()
    {
        countDialog = 0;
        dialogText.text = dataDialog[countDialog];
        GameManager.playDialog = true;
        PlayerPrefs.SetInt(addressDialog, 1);
    }

    private void Update()
    {
        NextDialog();
    }
    void NextDialog()
    {
        if (isEndDialog) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (countDialog < dataDialog.Length-1)
            {
                countDialog++;
                dialogText.text = dataDialog[countDialog];
            }
            else
            {
                isEndDialog = true;
                GameManager.playDialog = false;
                Destroy(gameObject);
            }
        }
    }
}
