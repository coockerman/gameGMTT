using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetCountVP : MonoBehaviour
{
    [SerializeField] int sttGet;
    public TextMeshProUGUI textCount;
    int countVP;
    private void Awake()
    {
        textCount = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        countVP = PlayerPrefs.GetInt("VatPham" + sttGet);
    }
    private void Update()
    {
        GetCountItem();
    }

    public void GetCountItem()
    {
        if (PlayerPrefs.GetInt("VatPham" + sttGet) != countVP)
        {
            countVP = PlayerPrefs.GetInt("VatPham" + sttGet);
        }
        textCount.text = "" + countVP;
    }
}
