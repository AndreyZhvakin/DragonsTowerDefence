using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    public int count;

    public TMP_Text text;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            count++;
            timer = 0;
        }
            
        text.SetText(count.ToString());
    }
}
