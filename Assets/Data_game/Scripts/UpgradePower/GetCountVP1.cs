using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetCountVP1 : MonoBehaviour
{
    public TextMeshProUGUI textCount;

    private void Awake()
    {
        textCount = GetComponent<TextMeshProUGUI>();
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
        textCount.text = "" + PlayerPrefs.GetInt("VatPham1");
    }
}
