using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        Debug.Log("NewGame");
        SceneManager.LoadScene(1);
    }

    public void Records()
    {
        Debug.Log("Records");
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene(2);

    }

    public void ConfirmYes()
    {
        Debug.Log("Yes");
        Application.Quit();
    }

    public void ConfirnNo()
    {
        Debug.Log("No");
        SceneManager.LoadScene(0);
    }
}
