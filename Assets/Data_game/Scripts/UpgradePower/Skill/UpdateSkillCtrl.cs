using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateSkillCtrl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeThongBaoBatTu;
    [SerializeField] SkillBatTu skillBatTu;
    

    int intTimeBatTu;
    float countTimeBatTu;
    private void Update()
    {
        CheckBatTu();
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
            intTimeBatTu = (int)(countTimeBatTu+0.5f);
            Debug.Log(intTimeBatTu);
            timeThongBaoBatTu.text = intTimeBatTu.ToString();
        }
        if (skillBatTu.activeBatTu == true) return;
        if (Input.GetKey(KeyCode.P))
        {
            skillBatTu.OnBatTu();
            countTimeBatTu = skillBatTu.timeBattu;
        }
        
    }
}
