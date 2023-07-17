using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Records : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("scope", 0) != 0)
        text.SetText("Player\t" + PlayerPrefs.GetFloat("scope", 0));
        Debug.Log("scope" + PlayerPrefs.GetFloat("scope", 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
