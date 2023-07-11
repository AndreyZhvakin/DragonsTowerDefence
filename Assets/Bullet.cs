using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0;
    public Vector3 diration = new Vector3(0,0,0);
    public float damage;

    public Vector3 startPosition;
    public float currentTimeOnPath = 0;

    public float pathLength;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BulletPos - " + gameObject.transform.position);
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0 && diration != new Vector3(0,0,0))
        {
            pathLength = Vector3.Distance(startPosition, diration);
            currentTimeOnPath += Time.deltaTime;
            float totalTimeForPath = pathLength / speed;
            gameObject.transform.position = Vector2.Lerp(startPosition, diration, currentTimeOnPath / totalTimeForPath);
            Debug.Log("Bullet fly" + gameObject.transform.position);

            if (diration == gameObject.transform.position)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
