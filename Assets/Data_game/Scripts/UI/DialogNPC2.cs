using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogNPC2 : MonoBehaviour
{
    [SerializeField] string nameDialog;
    [SerializeField] string addressDialog;
    [SerializeField] string[] dataDialog;
    GameManager gameManager;
    [SerializeField] TextMeshProUGUI dialogText;

    int countDialog;
    private void OnEnable()
    {
        countDialog = 0;
        gameManager = FindObjectOfType<GameManager>();
        dialogText.text = dataDialog[countDialog];
        gameManager.playDialog = true;
        PlayerPrefs.SetInt(addressDialog, 1);
    }

    private void Update()
    {
        NextDialog();
    }
    void NextDialog()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            if (countDialog < dataDialog.Length-1)
            {
                countDialog++;
                dialogText.text = dataDialog[countDialog];
            }
            else
            {
                gameManager.playDialog = false;
                Destroy(gameObject);
            }
        }
    }
}
