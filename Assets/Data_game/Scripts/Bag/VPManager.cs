using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VPManager : MonoBehaviour
{
    public TextMeshProUGUI textCount;

    private void Awake()
    {
        textCount = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        GetCountItem();
    }
    
    public void GetCountItem()
    {       
        textCount.text = "" + PlayerPrefs.GetInt(gameObject.name + "(Clone)");
    }
}
