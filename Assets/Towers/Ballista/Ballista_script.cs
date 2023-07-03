using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_script : MonoBehaviour
{
    public Animator animator;

    private List<GameObject> enemys_around = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool isEmpty = !enemys_around.Any();
        if (!isEmpty)
        {
            // rotate and fire 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //when a enemy enters
        if (other.tag == "Enemy")
        {
            enemys_around.Add(other);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        //when a enemy enters
        if (other.tag == "Enemy")
        {
            enemys_around.Remove(other);
        }
    }
}
