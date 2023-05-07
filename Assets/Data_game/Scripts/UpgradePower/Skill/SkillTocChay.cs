using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTocChay : MonoBehaviour
{
    [Header("Up = VatPham2")]
    [SerializeField] int[] dataNLUpTocChay;
    [SerializeField] float[] dataLVTimeTocChay;

    [SerializeField] PlayerCtrl playerctrl;

    [SerializeField] GameObject ImageThongBao;
    [SerializeField] GameObject HieuUng;

    [SerializeField] TextMeshProUGUI ChuThichTocChay;
    [SerializeField] TextMeshProUGUI textLvTocChay;
    [SerializeField] TextMeshProUGUI textNeedNL;

    public string SAVE_LVTocChay;
    public float timeTocChay;
    int lvTocChay;
    //public bool activeTocChay = false;

    private void Start()
    {
        SetTimeTocChay();
        SetChuThich();
    }

    public void OnTocChay()
    {
        //activeTocChay = true;
        SetTimeTocChay();

        ImageThongBao.SetActive(true);
        HieuUng.SetActive(true);

        playerctrl.runSpeed = 2*playerctrl.runSpeed;
        string NameFcTocChay = nameof(OffTocChay);
        Invoke(NameFcTocChay, timeTocChay);
    }
    void OffTocChay()
    {
        //activeTocChay = false;
        HieuUng.SetActive(false);
        ImageThongBao.SetActive(false);
        playerctrl.runSpeed = (0.5f) * playerctrl.runSpeed;
    }
    void SetTimeTocChay()
    {
        SAVE_LVTocChay = "lvTocChay";
        lvTocChay = PlayerPrefs.GetInt(SAVE_LVTocChay);
        timeTocChay = dataLVTimeTocChay[lvTocChay];
    }
    public void TangLVTocChay()
    {
        if (lvTocChay == 7) return;
        int vatpham2 = PlayerPrefs.GetInt("VatPham2");
        if (vatpham2 < dataNLUpTocChay[lvTocChay]) return;
        vatpham2 -= dataNLUpTocChay[lvTocChay];
        PlayerPrefs.SetInt("VatPham2", vatpham2);
        lvTocChay++;
        PlayerPrefs.SetInt(SAVE_LVTocChay, lvTocChay);
        SetChuThich();
    }
    void SetChuThich()
    {
        ChuThichTocChay.text = "Nhân vật x2 tốc độ di chuyển trong " + timeTocChay + "s";
        textLvTocChay.text = "Cấp " + lvTocChay;
        textNeedNL.text = "x" + dataNLUpTocChay[lvTocChay];
    }
}
