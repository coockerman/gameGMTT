using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    //public GameObject Enemy;
    public float xMin=1;
    public float xMax=5;
    public float yMin=1;
    public float yMax=5;

    
    // Start is called before the first frame update
    
    public void SpawnEnemy(GameObject Enemy)
    {
       //TimeSpawn = Random.Range(TimeSpawnMin, TimeSpawnMax);       
        GameObject enemy = Instantiate(Enemy);
        enemy.transform.position = new Vector3(Enemy.transform.position.x + Random.Range(xMin,xMax), Enemy.transform.position.y + Random.Range(yMin,yMax));
    }
}
