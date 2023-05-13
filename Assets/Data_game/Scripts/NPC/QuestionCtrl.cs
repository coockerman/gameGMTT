using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class VP{
    public int stt;
    public int count;
}
public class QuestionCtrl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshQuestion;
    [SerializeField] TextMeshProUGUI textMeshAnswerA;
    [SerializeField] TextMeshProUGUI textMeshAnswerB;
    [SerializeField] TextMeshProUGUI textPT;

    [SerializeField] string question;
    [SerializeField] string answerA;
    [SerializeField] string answerB;
    [SerializeField] int DapAn;

    [SerializeField] Image imgAnswerA;
    [SerializeField] Image imgAnswerB;

    [SerializeField] Color clTrue;
    [SerializeField] Color clFlase;

    BagCtrl bagCtrl;
    [SerializeField] string addressDialog;
    [SerializeField] VP[] vps;

    bool CheckAnswer;
    private void Start()
    {
        PlayerPrefs.SetInt(addressDialog, 1);
        bagCtrl = FindObjectOfType<BagCtrl>();
        GameManager.playDialog = true;
        CheckAnswer = false;
        textMeshQuestion.text = question;
        textMeshAnswerA.text = answerA;
        textMeshAnswerB.text = answerB;
        EditTextPT();
    }
    void CheckQua()
    {
        foreach(VP vp in vps)
        {
            bagCtrl.TangVatPham(vp.stt, vp.count);
        }
    }
    void EditTextPT()
    {
        string ptText = "";
        foreach (VP vp in vps)
        {
            ptText += "" + bagCtrl.GetNameVP(vp.stt) + " x" + vp.count + "\n"; 
        }
        textPT.text = ptText;
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
            CheckQua();
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
        GameManager.playDialog = false;
        gameObject.SetActive(false);
    }

}
