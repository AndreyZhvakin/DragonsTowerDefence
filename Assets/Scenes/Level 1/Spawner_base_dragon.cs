using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerScript : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnTime = 2f;

    private float timer = 0;

    

    void Start()
    {
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameObject newEnemy = (GameObject)Instantiate(spawnObject);
            timer = spawnTime;
        }
    }
}
