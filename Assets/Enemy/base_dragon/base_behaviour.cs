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

    private float pathLength;

    Vector3 startPosition;
    Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        //get points of the path
        PathLink = GameObject.Find("Path");
        points = PathLink.GetComponent<Path>().Points;

        //planning route at the first point
        startPosition = points[currentPoint].transform.position;
        endPosition = points[currentPoint + 1].transform.position;
        pathLength = Vector3.Distance(startPosition, endPosition);
    }

    // Update is called once per frame
    void Update()
    { 
        // animation
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
        

        //unknown cause, z not equal 0 for points anytime 
        endPosition.z = 0;


        //move
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        float totalTimeForPath = pathLength / speed;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);


        // on points
        if (gameObject.transform.position.Equals(endPosition))
        { 
            //last point 
            if (currentPoint+2 == points.Length)
            {
                Destroy(gameObject);
            }

            //planning a route to the next point
            currentPoint++;
            lastWaypointSwitchTime = Time.time;
            startPosition = points[currentPoint].transform.position;
            endPosition = points[currentPoint + 1].transform.position;
            pathLength = Vector3.Distance(startPosition, endPosition);
        }
    }
}

