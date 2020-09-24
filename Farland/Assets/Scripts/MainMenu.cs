using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnOptions()
    {
        //todo
    }
    public void OnExit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
