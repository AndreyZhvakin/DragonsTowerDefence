using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Health", health);
        if(health <= 0)
        {
            if (GameObject.Find("Scope").GetComponent<scope>().count > PlayerPrefs.GetFloat("scope",0))
            PlayerPrefs.SetFloat("scope", GameObject.Find("Scope").GetComponent<scope>().count); 
            SceneManager.LoadScene(4);
        }
    }
}
