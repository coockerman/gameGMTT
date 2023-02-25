using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    protected NV1_OpenEntry nv1;
    protected NV2_FarmVP nv2;
    protected NV3_OpenStore nv3;
    protected NV4_UpLV nv4;

    private void Awake()
    {
        nv1 = GetComponent<NV1_OpenEntry>();
        nv2 = GetComponent<NV2_FarmVP>();
        nv3 = GetComponent<NV3_OpenStore>();
        nv4 = GetComponent<NV4_UpLV>();
    }
    // Update is called once per frame
    void Update()
    {
        SetNV();
    }
    protected virtual void SetNV()
    {
        nv1.NV1OpenEntryy();
        nv2.NV2FarmVP();
        nv3.NV3PickUpApple();
        nv4.NV4UpLV();
    }
}
