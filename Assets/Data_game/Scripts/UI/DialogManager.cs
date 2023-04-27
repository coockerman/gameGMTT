using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DialogManager : MonoBehaviour
{
    [SerializeField] List<GameObject> dialogData;
    
    [SerializeField] List<GameObject> dialog;

    //[SerializeField] GameObject[] dialogs;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject AniQuestion;
    string SAVE_index;
    string SAVE_indexAdd;
    bool onDialog;
    int countDialog;
    
    private void Start()
    {
        AniQuestion.SetActive(true);

    }
    private void OnEnable()
    {
        SAVE_index = "indexDialog" + gameObject.name;
        SAVE_indexAdd = "indexAddDialog" + gameObject.name;
        PlayerPrefs.SetInt(SAVE_indexAdd, 0);

        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        countDialog = PlayerPrefs.GetInt(SAVE_index);
        if (countDialog >= dialog.Count)
        {
            AniQuestion.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R) && onDialog)
        {
            if (countDialog >= dialog.Count - 1)
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
        if (countDialog >= dialog.Count) return;

        Instantiate(dialog[countDialog]);
        countDialog++;
        PlayerPrefs.SetInt(SAVE_index, countDialog);
    }
    
    public void AddDialog()
    {
        dialog.Add(dialogData[PlayerPrefs.GetInt(SAVE_indexAdd)]);
        PlayerPrefs.SetInt(SAVE_indexAdd, PlayerPrefs.GetInt(SAVE_indexAdd)+1);
        if (countDialog < dialog.Count)
        {
            AniQuestion.SetActive(true);
        }
    }
    
}
