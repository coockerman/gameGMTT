using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCtrl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshQuestion;
    [SerializeField] TextMeshProUGUI textMeshAnswerA;
    [SerializeField] TextMeshProUGUI textMeshAnswerB;

    [SerializeField] string question;
    [SerializeField] string answerA;
    [SerializeField] string answerB;
    [SerializeField] int DapAn;

    [SerializeField] Image imgAnswerA;
    [SerializeField] Image imgAnswerB;

    [SerializeField] Color clTrue;
    [SerializeField] Color clFlase;

    GameManager gameManager;
    bool CheckAnswer;
    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.playDialog = true;
        CheckAnswer = false;
        textMeshQuestion.text = question;
        textMeshAnswerA.text = answerA;
        textMeshAnswerB.text = answerB;
    }
    public void CheckDapAn(int dapAn)
    {
        if (CheckAnswer == true) return;
        CheckAnswer = true;
        if(dapAn == DapAn)
        {
            if(DapAn == 1)
            {
                imgAnswerA.color = clTrue;
            }
            if(DapAn == 2)
            {
                imgAnswerB.color = clTrue;
            }
        }else
        {
            if(dapAn == 1)
            {
                imgAnswerB.color= clTrue;
                imgAnswerA.color = clFlase;
            }
            else
            {
                imgAnswerB.color= clFlase;
                imgAnswerA.color= clTrue;
            }
        }
        Invoke("SetObj", 2f);
    }
    private void SetObj()
    {
        gameManager.playDialog = false;
        gameObject.SetActive(false);
    }

}
