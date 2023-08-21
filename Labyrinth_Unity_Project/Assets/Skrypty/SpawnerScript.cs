using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] enemy1;

    public float timeBetweenSpawns;
    private float maxTimeBetweenSpawns;

    public GameObject[] spawnPoints;
    private int losValue;
    private int losEnemy;
    private int loslos;

    public int LevelNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        maxTimeBetweenSpawns = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        losEnemy = Random.Range(0, LevelNumber);
        

        if(losEnemy == 1)
        {
            loslos = Random.Range(0, 2);
            if (loslos == 1) losEnemy = 1;
            else losEnemy = 0;
        }
        else if(losEnemy == 2)
        {
            loslos = Random.Range(0, 3);
            if (loslos <= 1) losEnemy = 2;
            else losEnemy = Random.Range(0, LevelNumber - 1);
        }

        if(timeBetweenSpawns <= 0)
        {
            losValue = Random.Range(0, spawnPoints.Length);
            GameObject enemy1Obj = Instantiate(enemy1[losEnemy], spawnPoints[losValue].transform.position, Quaternion.identity);

            enemy1Obj.SetActive(true);
            timeBetweenSpawns = maxTimeBetweenSpawns;
        }else{

            timeBetweenSpawns -= Time.deltaTime;
        }


    }


}
