using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        //Application.LoadLevel("Level01");
        SceneManager.LoadScene("Level01");
    }
    public void Level()
    {
        //Application.LoadLevel("Level");
        SceneManager.LoadScene("Level");
    }
    public void Tutorial()
    {
        //Application.LoadLevel("tutorial");
        SceneManager.LoadScene("tutorial");
    }
    public void Level01()
    {
        SceneManager.LoadScene("Level01");
        //Application.LoadLevel("Level01");
    }
    public void Level02()
    {
        SceneManager.LoadScene("Level02");
        //Application.LoadLevel("Level02");
    }
    public void Level03()
    {
        SceneManager.LoadScene("Level03");
        //Application.LoadLevel("Level03");
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
