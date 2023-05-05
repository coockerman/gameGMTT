using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillBatTu : MonoBehaviour
{
    [Header("Up = VatPham2")]
    [SerializeField] int[] dataNLUpBatTu;
    [SerializeField] float[] dataLVTimeBatTu;

    [SerializeField] PlayerHearthManager playerHearth;

    [SerializeField] GameObject ImageThongBao;
    [SerializeField] GameObject HieuUng;

    [SerializeField] TextMeshProUGUI ChuThichBatTu;
    [SerializeField] TextMeshProUGUI textLvBatTu;
    [SerializeField] TextMeshProUGUI textNeedNL;

    string SAVE_LVBatTu;
    public float timeBattu;
    int lvBatTu;
    //public bool activeBatTu = false;
    
    private void Start()
    {
        SetTimeBatTu();
        SetChuThich();
    }
    
    public void OnBatTu()
    {
        //activeBatTu = true;
        SetTimeBatTu();

        ImageThongBao.SetActive(true);
        HieuUng.SetActive(true);

        playerHearth.BatTu2 = true;
        string NameFcBattu = nameof(OffBatTu);
        Invoke(NameFcBattu, timeBattu);
    }
    void OffBatTu()
    {
        //activeBatTu = false;
        HieuUng.SetActive(false);
        ImageThongBao.SetActive(false);
        playerHearth.BatTu2 = false;
    }
    void SetTimeBatTu()
    {
        SAVE_LVBatTu = "lvBatTu";
        lvBatTu = PlayerPrefs.GetInt(SAVE_LVBatTu);
        timeBattu = dataLVTimeBatTu[lvBatTu];
    }
    public void TangLVBattu()
    {
        if (lvBatTu == 7) return;
        int vatpham2 = PlayerPrefs.GetInt("VatPham2");
        if (vatpham2 < dataNLUpBatTu[lvBatTu]) return;
        vatpham2 -= dataNLUpBatTu[lvBatTu];
        PlayerPrefs.SetInt("VatPham2", vatpham2);
        lvBatTu++;
        PlayerPrefs.SetInt(SAVE_LVBatTu, lvBatTu);
        SetChuThich();
    }
    void SetChuThich()
    {
        ChuThichBatTu.text = "Nhân vật miễn mọi sát thương từ quái trong " + timeBattu + "s";
        textLvBatTu.text = "Cấp " + lvBatTu;
        textNeedNL.text = "x" + dataNLUpBatTu[lvBatTu];
    }
    
}
