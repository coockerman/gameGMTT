using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetHP : MonoBehaviour
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
        GetCountIndex();
    }

    public void GetCountIndex()
    {
        textCount.text = "" + PlayerPrefs.GetInt("playerHearth");
    }
}
