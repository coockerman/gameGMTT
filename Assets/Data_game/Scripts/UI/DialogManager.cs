using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject[] dialogs;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject AniQuestion;
    string SAVE_index;
    bool onDialog;
    int countDialog;
    private void OnEnable()
    {
        if(countDialog >= dialogs.Length)
        {
            AniQuestion.SetActive(false);
        }
        SAVE_index = "indexDialog" + gameObject.name;
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && onDialog)
        {
            if (countDialog >= dialogs.Length-1)
            {
                AniQuestion.SetActive(false);
            }
            OnDialog();
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onDialog = true;
        }
    }

    void OnDialog()
    {
        if (gameManager.playDialog == true) return;
        countDialog = PlayerPrefs.GetInt(SAVE_index);
        if (countDialog >= dialogs.Length) return;
        Instantiate(dialogs[countDialog]);
        countDialog++;
        PlayerPrefs.SetInt(SAVE_index, countDialog);
    }
}
