using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCountItem : MonoBehaviour
{
    
    protected TextMeshProUGUI textCount;
    private void Awake()
    {
        textCount= GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        GetCountItem();   
    }
    public void GetCountItem()
    {
        textCount.text = "" + PlayerPrefs.GetInt(gameObject.transform.parent.name);
        
    }
}
