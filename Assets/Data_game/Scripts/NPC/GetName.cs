using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetName : MonoBehaviour
{
    DialogNPC dialogNPC;
    TextMeshProUGUI nameNPC;
    private void Start()
    {
        dialogNPC = GetComponentInParent<DialogNPC>();
        nameNPC = GetComponent<TextMeshProUGUI>();
        nameNPC.text = dialogNPC.name;
    }

}
