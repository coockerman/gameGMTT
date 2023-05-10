using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class UpChiSo : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textCount;
    [SerializeField] int TangChiSo;
    [SerializeField] int SLVatPham;
    [SerializeField] int SttVatPham;
    protected virtual void Start()
    {
        GetCountIndex();
    }
    public void UpMoreChiSo(int SoLanUp)
    {
        string nameVP = "VatPham" + "1";
        if (PlayerPrefs.GetInt(nameVP) >= SLVatPham * SoLanUp)
        {
            UpChiSoCoBan(TangChiSo * SoLanUp);
            PlayerPrefs.SetInt(nameVP, PlayerPrefs.GetInt(nameVP) - SLVatPham * SoLanUp);
            GetCountIndex();
        }
    }
    protected virtual void UpChiSoCoBan(int TangChiSo) { }
    protected virtual void GetCountIndex() { }
    
}
