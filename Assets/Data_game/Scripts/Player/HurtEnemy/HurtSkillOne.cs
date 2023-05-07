using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSkillOne : HurtEnemy
{
    [SerializeField] AudioClip Chem;
    
    
    protected override void OnShot()
    {
        audioPlayer.PlayOneShot(Chem);
    }
}
