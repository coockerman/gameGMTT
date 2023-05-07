using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillHoiPhuc : MonoBehaviour
{
    [Header("Up = VatPham3")]
    [SerializeField] protected int[] dataNLUp;
    [SerializeField] protected float[] dataLVHoiPhuc;

    [SerializeField] protected TextMeshProUGUI ChuThichHoiPhuc;
    [SerializeField] TextMeshProUGUI textLv;
    [SerializeField] TextMeshProUGUI textNeedNL;
    public string SAVE_LV;
    protected float hoiPhuc;
    protected int lvHoiPhuc;
    //public bool activeHealth = false;

    private void Start()
    {
        SetTimeHoiPhuc();
        SetChuThich();
    }

    public virtual void OnHoiPhuc()
    {
        SetTimeHoiPhuc();
    }
    protected virtual void SetTimeHoiPhuc()
    {
        lvHoiPhuc = PlayerPrefs.GetInt(SAVE_LV);
        hoiPhuc = dataLVHoiPhuc[lvHoiPhuc];
    }
    public void TangLVHoiPhuc()
    {
        if (lvHoiPhuc == 7) return;

        int vatpham3 = PlayerPrefs.GetInt("VatPham3");
        if (vatpham3 < dataNLUp[lvHoiPhuc]) return;
        vatpham3 -= dataNLUp[lvHoiPhuc];
        PlayerPrefs.SetInt("VatPham3", vatpham3);

        lvHoiPhuc++;
        PlayerPrefs.SetInt(SAVE_LV, lvHoiPhuc);
        SetChuThich();
    }
    protected virtual void SetChuThich()
    {
        textLv.text = "Cấp " + lvHoiPhuc;
        textNeedNL.text = "x" + dataNLUp[lvHoiPhuc];
    }
}
