using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject PauseMenu;

    public static int levelNum;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                PauseMenu.gameObject.SetActive(true);
                CursorLock(false);
                Time.timeScale = 0;
            }
            else
            {
                PauseMenu.gameObject.SetActive(false);
                CursorLock(true);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    public static void LoadScene0()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void LoadScene0Button()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void LoadScene1()
    {
        levelNum = 0;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void LoadScene2()
    {
        levelNum = 1;
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void LoadScene3()
    {
        levelNum = 2;
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void CursorLock(bool Value)
    {
        if (Value)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
