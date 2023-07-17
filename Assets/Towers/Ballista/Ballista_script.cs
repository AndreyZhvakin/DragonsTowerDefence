using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista_script : MonoBehaviour
{
    public Animator animator;

    private List<GameObject> enemys_around = new List<GameObject>();
    private GameObject aim;

    private bool already_fire = false;
    private float lastFire = 0;

    public GameObject bulletPrefab;
    public GameObject currentBullet;
    public float bulletSpeed;

    public float health;

    public int price;

    // Start is called before the first frame update
    void Start()
    {
    }

    void ChooseAim()
    {
        // choose enemy from enemys_around for fire
        aim = enemys_around[0];
        Debug.Log("Len enemy - " + enemys_around.Count);
        foreach (GameObject enemy in enemys_around)
        {
            
            Debug.Log("Enemy RestPath - " + enemy.GetComponent<base_behaviour>().RestOfPath + enemy.name);
            if (aim.GetComponent<base_behaviour>().RestOfPath > enemy.GetComponent<base_behaviour>().RestOfPath)
            {
                aim = enemy;

            }
        }
        Debug.Log("Aim - " + aim);
    }

    void RotateToAim()
    {
        Vector3 diration = aim.transform.position - gameObject.transform.position;
        float angle = Vector3.Angle(diration, transform.up);
        Debug.Log("diration" + diration);
        Debug.Log("angle" + angle);

        if (angle < 22.5)
        {
            //up
            animator.SetInteger("duration",0);
        }
        else
        {
            if (diration.x > 0)
            {
                if (angle <= 22.5 * 3)
                {
                    animator.SetInteger("duration", 1);
                }
                else if (angle <= 22.5 * 5)
                {
                    animator.SetInteger("duration", 2);
                }
                else if (angle <= 22.5 * 7)
                {
                    animator.SetInteger("duration", 3);
                }
                else if (angle <= 22.5 * 8)
                {
                    animator.SetInteger("duration", 4);
                }
            }
            else
            {
                if (angle <= 22.5 * 3)
                {
                    animator.SetInteger("duration", 7);
                }
                else if (angle <= 22.5 * 5)
                {
                    animator.SetInteger("duration", 6);
                }
                else if (angle <= 22.5 * 7)
                {
                    animator.SetInteger("duration", 5);
                }
                else if (angle <= 22.5 * 8)
                {
                    animator.SetInteger("duration", 4);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (already_fire)
        {
            if (aim != null && enemys_around.Contains(aim))
            {
                //if the aim still live and he's around
                //FIRE!
            }
            else
            {
                //if the aim has dead or he's not aroud
                if(enemys_around.Count != 0)
                {
                    ChooseAim();
                    //already_fire = true;
                }
                else
                {
                    //stop fire
                    already_fire = false;
                }
            }
        }
        else if (enemys_around.Count != 0)
        {
            //when there are enemys around
            ChooseAim();
            already_fire = true;
        }

        if(aim != null)
            RotateToAim();

        lastFire += Time.deltaTime;
        if (already_fire && lastFire >= 1)
        {
            Debug.Log("Fire!!!");
            //spawn bullet
            currentBullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
            //set its diration and speed
            currentBullet.GetComponent<Bullet>().speed = bulletSpeed;

            Vector3 diration = aim.transform.position;
            currentBullet.GetComponent<Bullet>().diration = diration;

            lastFire = 0;
        }
        //animator.SetBool("fire", already_fire);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //when a enemy enters
        if (other.tag == "Enemy")
        {
            enemys_around.Add(other.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        //when a enemy exits
        if (other.tag == "Enemy")
        {
            enemys_around.Remove(other.gameObject);
        }
    }
}
