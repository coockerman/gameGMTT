using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dBox;
    public TextMeshProUGUI dText;

    public string dialogText;
    

    public void Start()
    {
    }
    public void Update()
    {
        SetActiveBox();
    }
    protected void SetActiveBox()
    {
        
        dText.text = dialogText;
    }
    public void CloseBox()
    {
        dBox.SetActive(false);
    }
    public void OnBox()
    {
        dBox.SetActive(true);
    }
}
