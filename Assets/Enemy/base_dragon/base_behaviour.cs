using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_behaviour : MonoBehaviour
{

    public Animator animator;

    private GameObject PathLink;

    private int currentPoint = 0;
    private float lastWaypointSwitchTime;

    public float speed = 0.05f;

    private GameObject[] points;

    public float health;
    private float maxHealth;

    public float RestOfPath = 0;
    private float pathLength;

    Vector3 startPosition;
    Vector3 endPosition;

    void ChooseAnimation()
    {
        Vector3 diration = endPosition - startPosition;
        if (diration.x > diration.y)
        {
            if (diration.x > -diration.y)
            {
                //right
                animator.SetInteger("diration", 1);
            }
            else
            {
                //forward
                animator.SetInteger("diration", 0);
            }
        }
        else
        {
            //left
            animator.SetInteger("diration", 2);
        }
    }

    void planRoute()
    {
        //planning route at a point
        startPosition = points[currentPoint].transform.position;
        endPosition = points[currentPoint + 1].transform.position;
        pathLength = Vector3.Distance(startPosition, endPosition);

        //unknown cause, z not equal 0 for points anytime 
        endPosition.z = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //get points of the path
        PathLink = GameObject.Find("Path");
        points = PathLink.GetComponent<Path>().Points;

        //RestOfPath = PathLink.GetComponent<Path>().Lenght;

        lastWaypointSwitchTime = Time.time;

        //move
        planRoute();
        ChooseAnimation();

        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Golds").GetComponent<Gold>().count += 2;
            GameObject.Find("Scope").GetComponent<scope>().count += maxHealth / 25;
            Debug.Log("+scope - " + maxHealth / 25);
        }
        //move
        Vector3 last_position = gameObject.transform.position;

        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        float totalTimeForPath = pathLength / speed;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        RestOfPath -= Time.deltaTime*speed;

        // on points
        if (gameObject.transform.position.Equals(endPosition))
        { 
            //last point 
            if (currentPoint+2 == points.Length)
            {
                Destroy(gameObject);
                GameObject.Find("Health").GetComponent<Health>().health -= 1;
            }
            else
            {
                //planning a route to the next point
                currentPoint++;
                lastWaypointSwitchTime = Time.time;

                planRoute();
                ChooseAnimation();
            }
        }
    }
}

