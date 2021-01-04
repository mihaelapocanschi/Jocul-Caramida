using UnityEngine;
using System.Collections;


public class SpawnManager : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject brick;
    public GameObject brickTrigger;

    float waitForNewWave = 1.5f;
    float timeToSpawn = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Time.time > timeToSpawn)
        {
            Spawn();
            timeToSpawn = Time.time + waitForNewWave;
        }
	}

    //Functie pentru a instantia obstacolele in linie
    void Spawn()
    {
        int index = Random.Range(0, spawnPoints.Length);
        for(int i =0;i < spawnPoints.Length;i++)
        {
            if (index != i)
                Instantiate(brick, spawnPoints[i].transform.position, Quaternion.identity);
            else if(index == i)
            {
                Instantiate(brickTrigger, spawnPoints[i].transform.position , Quaternion.identity);
            }
        }



    }
}
