using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void StartGame() //Start the game
    {
        Debug.Log("Start the game");
        SceneManager.LoadScene("Expo Hall 2");
    }

    public void NewGame() //Start Demo game
    {
        Debug.Log("Made new game");
        SceneManager.LoadScene("Expo Hall 2");
    }

    public void GotoOM() //Go to Options Menu
    {
        SceneManager.LoadScene("Options Start Menu");
    }

    public void Credits() //Play credits
    {
        Debug.Log("Roll credits");
        //SceneManager.LoadScene("");
    }

    public void GotoSM() //Go to the Start Menu
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame() //Quit the game
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
    
}
