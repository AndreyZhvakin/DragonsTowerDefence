using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class TowerBuild : MonoBehaviour
{


    private double XtileSize = 37.5141176;
    private double YtileSize = 37.88;
    public GameObject angle;
    private GameObject towerPrefab = null;
    public GameObject ballista;


    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createTower()
    {
        if(towerPrefab != null && GameObject.Find("Golds").GetComponent<Gold>().count >= 10)
        {
            Vector3 mouse = Input.mousePosition - angle.transform.position;
            double XTile = Math.Truncate(mouse.x / (XtileSize*1.6));
            double YTile = Math.Truncate(mouse.y / (YtileSize*1.6));
            Debug.Log("XTile - " + XTile);
            Debug.Log("YTile - " + YTile);

            Vector3 positonTower = new Vector3
            {
                x = (float)(XTile + 0.5),
                y = (float)((YTile + 0.5) * 1.05),
                z = 0
            };

            Debug.Log("positonTower - " + positonTower);

            positonTower = positonTower + angle.transform.position;
            positonTower.z = 0;
            Instantiate(towerPrefab, positonTower, Quaternion.identity);

            GameObject.Find("Golds").GetComponent<Gold>().count -= 10;

            towerPrefab = null;


        }
    }

    public void selectBallista()
    {
        towerPrefab = ballista;
    }
}
