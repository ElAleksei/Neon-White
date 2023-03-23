using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "FinishScene")
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
