using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTER");
        if (other.tag == "Bullet")
        {
            Debug.Log("ENTER BULLET!");
            gameObject.transform.parent.gameObject.GetComponent<base_behaviour>().health -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
            Debug.Log("Health" + gameObject.transform.parent.gameObject.GetComponent<base_behaviour>().health);
        }
    }
}
