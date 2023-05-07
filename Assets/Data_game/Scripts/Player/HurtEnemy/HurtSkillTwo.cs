using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSkillTwo : HurtEnemy
{
    [SerializeField] AudioClip Dam;

    
    protected override void OnShot()
    {
        audioPlayer.PlayOneShot(Dam);
    }
}
