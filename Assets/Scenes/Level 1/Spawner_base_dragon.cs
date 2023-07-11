using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerScript : MonoBehaviour
{
    public GameObject baseDragon;
    public GameObject strongDragon;
    
    public float spawnTime = 2f;

    private float timer = 0;

    private int wave_number;

    public int wave_pause;
    private float wave_pause_time;
    private bool wave_pause_bool;

    private bool start_wave = true;
    private int enemy_count;
    public int chance_strong;

    void Start()
    {
        wave_pause_time = wave_pause;
    }

    void Update()
    {
        if(wave_pause_bool)
        {
            wave_pause_time-= Time.deltaTime;
            if(wave_pause_time<0)
            {
                wave_pause_bool = false;
                start_wave = true;
            }
        }
        else
        {
            if (start_wave)
            {
                //show wave number
                wave_number++;
                GameObject.Find("Wave").GetComponent<Wave>().count += 1;
                spawnTime = spawnTime * (1 - (wave_number - 1) / 10);
                if (chance_strong < 10)
                    chance_strong = (wave_number - 1);
                Debug.Log("chance_strong " + chance_strong);
                enemy_count = wave_number + 5;
                if (wave_number > 5)
                    enemy_count = wave_number + 10;
                start_wave = false;
            }

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                int chance = Random.Range(0, 10);
                Debug.Log("chance: " + chance);
                if (chance < chance_strong)
                {
                    GameObject newEnemy = (GameObject)Instantiate(strongDragon);
                }
                else
                {
                    GameObject newEnemy = (GameObject)Instantiate(baseDragon);
                }


                enemy_count--;
                timer = spawnTime;
                if (enemy_count == 0)
                    wave_pause_bool = true;
            }
        }
    }
  
}
