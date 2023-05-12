using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCtrl : MonoBehaviour
{
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
        switch(stt)
        {
            case 1:
                return "Giấy cường hoá";
            case 2:
                return "Đá tăng cấp";
            case 3:
                return "Đùi gà";
            case 4:
                return "Sách";
            case 5:
                return "Thỏi bạc";
            case 6:
                return "Dây chuyền";
            case 7:
                return "Đá hoả";
            case 8:
                return "Đá phong";
            case 9:
                return "Đá thuỷ";
            case 10:
                return "Nhẫn";
        }
        return "";
    }
}
