using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCtrl : MonoBehaviour
{
    public void TangVatPham(int stt, int count)
    {
        PlayerPrefs.SetInt("VatPham" + stt, count);
    }
    public void TangVatPham(string name,int count)
    {
        PlayerPrefs.SetInt(name, count);
    }
}
