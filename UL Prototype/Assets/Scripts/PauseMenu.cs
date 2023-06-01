using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject upgradeMenu;
    public GameObject InGameButtons;
    public GameObject settingsMenu;
    public GameObject journalMenu;
    public GameObject Player;
    public GameObject ArenaControl;
    public Toggle Green1;
    public Toggle Green2;
    public Toggle Green3;
    public Toggle Purple1;
    public Toggle Purple2;
    public Toggle Purple3;
    public static bool isPaused;
    public bool InMenu = false;
    public int UpgradeNumber = 0;
    public bool HasUpgraded = false;

    public ColorBlock GreenSelected;
    public ColorBlock PurpleSelected;
    public ColorBlock DefaultColor;

    void Start()
    {
        pauseMenu.SetActive(false); //Start game without pause menu
        upgradeMenu.SetActive(false); //Start game without pause menu
        settingsMenu.SetActive(false); //Start game without settings menu
        journalMenu.SetActive(false); //Start game without journal menu
        InGameButtons.SetActive(true); //Showgame menu

        GreenSelected = Green1.colors;
        GreenSelected.normalColor = Color.green;
        GreenSelected.selectedColor = Color.green;
        PurpleSelected = Purple1.colors;
        PurpleSelected.normalColor = Color.magenta;
        PurpleSelected.selectedColor = Color.magenta;

        DefaultColor = Green1.colors;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))//When press esc = Pause menu
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.J))//When press esc = Pause menu
        {
            UpgradeMenu();
        }
    }

    public void PauseGame() //Pull up pause menu and pause game
    {
        Cursor.lockState = CursorLockMode.Confined;
        InMenu = true;
        pauseMenu.SetActive(true);
        InGameButtons.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void UpgradeMenu() //Pull up upgrade menu and pause game
    {
        Cursor.lockState = CursorLockMode.Confined;
        InMenu = true;
        upgradeMenu.SetActive(true);
        InGameButtons.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void JournalMenu() //Pull up journal and pause game
    {
        Cursor.lockState = CursorLockMode.Confined;
        InMenu = true;
        InGameButtons.SetActive(false);
        journalMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame() //Put away pause menu and unpause game
    {
        Cursor.lockState = CursorLockMode.Locked;
        InMenu = false;
        pauseMenu.SetActive(false);
        upgradeMenu.SetActive(false);
        journalMenu.SetActive(false);
        InGameButtons.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        GameObject.Find("Controller").GetComponent<GameController>().UpgradeDescription = null;
        HasUpgraded = false;
    }

    #region In UpgradeMenu
    public void GreenUpgrade1()     //Green Upgrade 1
    {
        
            ArenaControl.GetComponent<ArenaControl>().SkillPoints -= 1;
            Debug.Log("Green Upgrade 1");
            Player.GetComponent<PlayerBehaviour>().ScanType = 1;
            Green1.colors = GreenSelected;
            Purple1.colors = DefaultColor;
            HasUpgraded = true;
        
        
        //Do something
    }
    public void GreenUpgrade2()     //Green Upgrade 2
    {
        
            ArenaControl.GetComponent<ArenaControl>().SkillPoints -= 1;
            Debug.Log("Green Upgrade 2");
            Player.GetComponent<PlayerBehaviour>().HackType = 1;
            Green2.colors = GreenSelected;
            Purple2.colors = DefaultColor;
            HasUpgraded = true;
        

        //Do something
    }
    public void GreenUpgrade3()     //Green Upgrade 3
    {
        
            ArenaControl.GetComponent<ArenaControl>().SkillPoints -= 1;
            Debug.Log("Green Upgrade 3");
            Player.GetComponent<PlayerBehaviour>().MeleeType = 1;
            Green3.colors = GreenSelected;
            Purple3.colors = DefaultColor;
            HasUpgraded = true;
        

        //Do something
    }

    public void GrayUpgrade1()     //Gay Upgrade 1
    {
        
            ArenaControl.GetComponent<ArenaControl>().SkillPoints -= 1;
            Debug.Log("Gray Upgrade 1");
            Player.GetComponent<PlayerBehaviour>().ScanType = 2;
            Purple1.colors = PurpleSelected;
            Green1.colors = DefaultColor;
            HasUpgraded = true;
        


        //Do something
    }
    public void GrayUpgrade2()     //Gay Upgrade 2
    {
        
            ArenaControl.GetComponent<ArenaControl>().SkillPoints -= 1;
            Debug.Log("Gray Upgrade 2");
            Player.GetComponent<PlayerBehaviour>().HackType = 2;
            Purple2.colors = PurpleSelected;
            Green2.colors = DefaultColor;
            HasUpgraded = true;
        
        //Do something
    }
    public void GrayUpgrade3()     //Gay Upgrade 3
    {
        
            ArenaControl.GetComponent<ArenaControl>().SkillPoints -= 1;
            Debug.Log("Gray Upgrade 3");
            Player.GetComponent<PlayerBehaviour>().MeleeType = 2;
            Purple3.colors = PurpleSelected;
            Green3.colors = DefaultColor;
            HasUpgraded = true;
        
        //Do something
    }
    #endregion

    #region In OptionsMenu
    public void Save()     //Save the game
    {
        Debug.Log("Don't forget to save progress");
        //SceneManager.LoadScene("");
    }
    public void Settings() //Settings
    {
        upgradeMenu.SetActive(false);
        settingsMenu.SetActive(true);
        InGameButtons.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void GoToMM() //Go to the main menu
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }
    #endregion

}
