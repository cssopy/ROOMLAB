using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public float spawnRange;
    public float amountToSpawn;
    private Vector3 spawnPoint;
    public GameObject asteroid;
    public List<GameObject> asteroids = new List<GameObject>();
    public float startSafeRange;
    private List<GameObject> objectsToPlace = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            PickSpawnPoint();

            //pick new spawn point if too close to player start
            while (Vector3.Distance(spawnPoint, Vector3.zero) < startSafeRange)
            {
                PickSpawnPoint();
            }

            int index = Random.Range(0, 5);

            objectsToPlace.Add(Instantiate(asteroids[index], spawnPoint, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
            objectsToPlace[i].transform.parent = this.transform;
        }

        asteroids[0].SetActive(false);
        asteroids[1].SetActive(false);
        asteroids[2].SetActive(false);
        asteroids[3].SetActive(false);
        asteroids[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickSpawnPoint()
    {
        spawnPoint = new Vector3(
            Random.Range(-1f,1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f));

        if(spawnPoint.magnitude > 1)
        {
            spawnPoint.Normalize();
        }

        spawnPoint *= spawnRange;
    }
}

