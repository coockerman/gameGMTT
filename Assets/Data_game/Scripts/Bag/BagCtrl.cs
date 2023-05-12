using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCtrl : MonoBehaviour
{
    [SerializeField] string[] nameVP;
    public void TangVatPham(int stt, int count)
    {
        PlayerPrefs.SetInt("VatPham" + stt, PlayerPrefs.GetInt("VatPham" + stt) + count);
    }
    public void TangVatPham(string name,int count)
    {
        PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) + count);
    }
    public string GetNameVP(int stt)
    {
        return nameVP[stt - 1];
    }
}
