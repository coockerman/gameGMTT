using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadBurst : MonoBehaviour
{
    [SerializeField] List<GameObject> bullets;
    
    [SerializeField] Transform boxBurst;
    [SerializeField] List<GameObject> particleSystems;
    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = transform;
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            GameObject childObj = parentTransform.GetChild(i).gameObject;
            AddObjectToPool(childObj);
        }
        for (int i = 0; i < boxBurst.childCount; i++)
        {
            GameObject childObj = boxBurst.GetChild(i).gameObject;
            AddBurstToPool(childObj);
        }
        AddParticle();
    }
    void AddObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        bullets.Add(obj);
    }
    void AddBurstToPool(GameObject particle)
    {
        //particle.SetActive(false);
        particleSystems.Add(particle);
    }    
    void AddParticle()
    {
        foreach(GameObject obj in bullets)
        {
            int i = bullets.IndexOf(obj);
            ParticleSystem a = particleSystems[i].GetComponent<ParticleSystem>();
            obj.GetComponent<HurtPlayer>().damageBurst = a;
        }
    }
    
}
