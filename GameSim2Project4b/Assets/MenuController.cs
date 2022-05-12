using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public MenuFlicker menuFlick;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void PlayGame()
    {
        
        
        //SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        menuFlick.FlickMenu();
        
        
        
        
        
    }
}
