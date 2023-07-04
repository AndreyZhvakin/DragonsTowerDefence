using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject[] Points;
    public float Lenght = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Points.Length-1; i++)
        {
            Lenght += Vector3.Distance(Points[i].transform.position, Points[i+1].transform.position);
        }
        Debug.Log("Length of path - " + Lenght);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
