using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetName : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI nameNPC;
    private void Start()
    {
        nameNPC.text = gameObject.name;
    }

}
