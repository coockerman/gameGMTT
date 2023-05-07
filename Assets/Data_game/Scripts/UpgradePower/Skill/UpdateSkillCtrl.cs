using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateSkillCtrl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeThongBaoBatTu;
    [SerializeField] TextMeshProUGUI timeThongBaoTocChay;

    [SerializeField] TextMeshProUGUI timeThongBaoDacBiet;
    [SerializeField] TextMeshProUGUI timeThongBaoHoiPhuc;

    [SerializeField] SkillBatTu skillBatTu;
    [SerializeField] SkillTocChay skillTocChay;
    [SerializeField] SkillHoiHp skillHoiHp;
    [SerializeField] SkillHoiKi skillHoiKi;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject textLV5;
    [SerializeField] GameObject textLV7;
    [SerializeField] GameObject textNangKyNang;
    bool checkDB = false;
    int TimeCDDacBiet;
    float countTimeDacBiet;

    bool checkHP = false;
    int TimeCDHoiPhuc;
    float countTimeHoiPhuc;

    int TimeCDBatTu;
    float countTimeBatTu;

    int TimeCDTocChay;
    float countTimeTocChay;
    private void Start()
    {
        TimeCDDacBiet = 30;
        TimeCDHoiPhuc = 60;
    }
    private void Update()
    {
        
        OnSkillDB();
        CheckBatTu();
        CheckTocChay();
        OnSkillHoiPhuc();
    }
    private void CheckBatTu()
    {
        if (countTimeBatTu > 0)
        {
            if (countTimeBatTu < 0)
            {
                countTimeBatTu = 0;
                return;
            }
            countTimeBatTu -= Time.deltaTime;
            TimeCDBatTu = (int)(countTimeBatTu);
            timeThongBaoBatTu.text = TimeCDBatTu.ToString() + "s";
        }
    }
    private void CheckTocChay()
    {
        if (countTimeTocChay > 0)
        {
            if (countTimeTocChay < 0)
            {
                countTimeTocChay = 0;
                return;
            }
            countTimeTocChay -= Time.deltaTime;
            TimeCDTocChay = (int)(countTimeTocChay);
            timeThongBaoTocChay.text = TimeCDTocChay.ToString() + "s";
        }
    }
    private void OnSkillDB()
    {
        if (countTimeDacBiet > 0)
        {
            countTimeDacBiet -= Time.deltaTime;
            float t = countTimeDacBiet;
            timeThongBaoDacBiet.text = ((int)t).ToString() + "s";
        }
        if (countTimeDacBiet <= 0 && checkDB)
        {
            timeThongBaoDacBiet.gameObject.SetActive(false);
            checkDB = false;
        }
        
        if (Input.GetKeyDown(KeyCode.P) && !checkDB)
        {
            if (PlayerPrefs.GetInt("playerLV") < 5)
            {
                Instantiate(textLV5, Player.transform.position, Player.transform.rotation);
                return;
            }
            if(PlayerPrefs.GetInt(skillBatTu.SAVE_LVBatTu) == 0 
                && PlayerPrefs.GetInt(skillTocChay.SAVE_LVTocChay) == 0)
            {
                Instantiate(textNangKyNang, Player.transform.position, Player.transform.rotation);
                return;
            }
            checkDB = true;
            timeThongBaoDacBiet.gameObject.SetActive(true);
            countTimeDacBiet = TimeCDDacBiet;

            skillBatTu.OnBatTu();
            countTimeBatTu = skillBatTu.timeBattu;

            skillTocChay.OnTocChay();
            countTimeTocChay = skillTocChay.timeTocChay;
        }
    }
    void OnSkillHoiPhuc()
    {
        if (countTimeHoiPhuc > 0)
        {
            countTimeHoiPhuc -= Time.deltaTime;
            float t = countTimeHoiPhuc;
            timeThongBaoHoiPhuc.text = ((int)t).ToString() + "s";
        }
        if (countTimeHoiPhuc <= 0 && checkHP)
        {
            timeThongBaoHoiPhuc.gameObject.SetActive(false);
            checkHP = false;
        }
        
        if (Input.GetKeyDown(KeyCode.O) && !checkHP)
        {
            if (PlayerPrefs.GetInt("playerLV") < 7)
            {
                Instantiate(textLV7, Player.transform.position, Player.transform.rotation);
                return;
            }
            if (PlayerPrefs.GetInt(skillHoiHp.SAVE_LV) == 0
                && PlayerPrefs.GetInt(skillHoiKi.SAVE_LV) == 0)
            {
                Instantiate(textNangKyNang, Player.transform.position, Player.transform.rotation);
                return;
            }
            checkHP = true;
            timeThongBaoHoiPhuc.gameObject.SetActive(true);
            countTimeHoiPhuc = TimeCDHoiPhuc;
            skillHoiHp.OnHoiPhuc();
            skillHoiKi.OnHoiPhuc();
        }
    }
}
