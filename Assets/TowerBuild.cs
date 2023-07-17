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
    public GameObject pushka;

    private List<string> pathTile = new List<string>();
    


    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        XtileSize = 0.05;
        YtileSize = 0.090909;

        pathTile.Add("70");
        pathTile.Add("71");
        pathTile.Add("72");
        pathTile.Add("73");
        pathTile.Add("63");
        pathTile.Add("53");
        pathTile.Add("43");
        pathTile.Add("33");
        pathTile.Add("34");
        pathTile.Add("35");
        pathTile.Add("36");
        pathTile.Add("46");
        pathTile.Add("56");
        pathTile.Add("66");
        pathTile.Add("76");
        pathTile.Add("86");
        pathTile.Add("96");
        pathTile.Add("106");
        pathTile.Add("116");
        pathTile.Add("115");
        pathTile.Add("114");
        pathTile.Add("113");
        pathTile.Add("112");
        pathTile.Add("122");
        pathTile.Add("132");
        pathTile.Add("142");
        pathTile.Add("143");
        pathTile.Add("144");
        pathTile.Add("145");
        pathTile.Add("146");
        pathTile.Add("147");
        pathTile.Add("148");

        pathTile.Add("138");
        pathTile.Add("128");
        pathTile.Add("118");
        pathTile.Add("108");
        pathTile.Add("98");
        pathTile.Add("88");
        pathTile.Add("78");
        pathTile.Add("68");
        pathTile.Add("58");
        pathTile.Add("48");
        pathTile.Add("38");
        pathTile.Add("28");

        pathTile.Add("29");
        pathTile.Add("210");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createTower()
    {
        if(towerPrefab != null && GameObject.Find("Golds").GetComponent<Gold>().count >= towerPrefab.GetComponent<Ballista_script>().price)
        {
            Vector3 mouse_pos = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0);

            Debug.Log("mouse_pos - " + mouse_pos);
            Vector3 mouse = mouse_pos;
            double XTile = Math.Truncate(mouse.x / (XtileSize));
            double YTile = Math.Truncate(mouse.y / (YtileSize));
            Debug.Log("XTile - " + XTile);
            Debug.Log("YTile - " + YTile);

            string XY = XTile.ToString() + YTile.ToString();
            Debug.Log("XY - " + XY);
            if (!pathTile.Contains(XY))
            {
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

                GameObject.Find("Golds").GetComponent<Gold>().count -= towerPrefab.GetComponent<Ballista_script>().price;

                towerPrefab = null;
            }
        }
    }

    public void selectBallista()
    {
        towerPrefab = ballista;
    }

    public void selectPushka()
    {
        towerPrefab = pushka;
    }
}
