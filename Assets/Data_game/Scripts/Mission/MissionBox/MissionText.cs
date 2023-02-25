using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionText : MonoBehaviour
{
    public TextMeshProUGUI textMission;
    private void Awake()
    {
        textMission = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Update()
    {
        updateMission(PlayerPrefs.GetInt("MissionMng"));
    }
    protected virtual void updateMission(int mission)
    {
        if (mission == 1)
        {
            textMission.text = "NV1: Hãy gặp Bon và trò chuyện với ông ấy" + "\n";
            if (PlayerPrefs.GetInt("dialogIndexBon") >= 13)
            {
                textMission.text += "Tiêu diệt quái vật và lên lv2";
            }
        }
        else if (mission == 2)
        {
            textMission.text = "NV2: Vào nhà tìm Brum và trò chuyện với ông ấy" + "\n";
            if (PlayerPrefs.GetInt("dialogIndexBrum") >= 7)
            {
                textMission.text += "Tìm kiếm 3 cuốn sách bằng cách tiêu diệt quái vật ở map chính";
            }
        }
        else if (mission == 3)
        {
            textMission.text = "NV3: Vào lại nhà gặp Brum";
        }
        else if(mission == 4)
        {
            textMission.text = "NV4: Hãy tìm đường đến cửa hàng" + "\n";
            if (PlayerPrefs.GetInt("dialogIndexMai") >= 9)
            {
                textMission.text += "Farm quái lên lv4";
            }
        }
        else if(mission == 5)
        {
            textMission.text = "NV5: Trò chuyện với Atan" + "\n";
            if (PlayerPrefs.GetInt("dialogIndexAtan") >= 6)
            {
                textMission.text += "Tìm tên Ăn trộm";
            }
        }
        else
        {
            textMission.text = "Nhiệm vụ đang cập nhập";
        }
    }

}
