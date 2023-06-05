using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float Pollution = 5;
    public string CurrentMessage1;
    public string CurrentMessage2;
    public string CurrentMessage3;
    public string UpgradeDescription;
    public bool CluesFound = false;
    private GUIStyle Message = new GUIStyle();
    private GUIStyle UI = new GUIStyle();
    public GameObject Camera;
    public GameObject Player;
    public GameObject ArenaControl;
    public GameObject Podium;
    public GameObject Body;
    public GameObject Bullet;
    public GameObject AfterStageTrigger;
    public GameObject PhilaExplainTrigger;
    public GameObject ScanTrigger;
    public GameObject TinkerTrigger;
    public GameObject StageTrigger;
    public GameObject Mission1;
    public GameObject Mission2;
    public GameObject Mission3;
    public TextMeshProUGUI TextDisplayer;
    public TextMeshProUGUI AmmoCount;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.E))
        {
            CurrentMessage1 = null;
            CurrentMessage2 = null;
            CurrentMessage3 = null;
        }

        //Spawn Bullet Clue
        if (Body.GetComponent<ObjectInteraction>().Interacted)
        {
            Bullet.SetActive(true);
        }


        if (Body.GetComponent<ObjectInteraction>().Interacted && Podium.GetComponent<ObjectInteraction>().Interacted && Bullet.GetComponent<ObjectInteraction>().Interacted && TextDisplayer.text == string.Empty && CluesFound == false)
        {
            //if (Player.transform.rotation.y < 140 && Player.transform.rotation.y > 60)
            {
                TextDisplayer.GetComponent<TextDisplay>().lines[0] = "And there we have it, three possible locations for the killer, more of a sniper really";
                TextDisplayer.GetComponent<TextDisplay>().lines[1] = "I should probably go investigate";
                TextDisplayer.GetComponent<TextDisplay>().StartDialogue();
                CluesFound = true;
                AfterStageTrigger.SetActive(true);
                PhilaExplainTrigger.SetActive(true);
                TinkerTrigger.SetActive(true);
                Mission1.SetActive(false);
                Mission2.SetActive(true);
            }
        }

        AmmoCount.text = Camera.GetComponent<Shooting>().CAmmo + "/" + Camera.GetComponent<Shooting>().CTotalAmmo;

        if (StageTrigger.GetComponent<TriggerBehaviour>().IsTriggered && TextDisplayer.text == string.Empty)
        {
            ScanTrigger.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScanTrigger.SetActive(false);
        }



    }

    private void OnGUI()
    {
        Message.fontSize = 40;
        Message.alignment = TextAnchor.MiddleCenter;
        UI.fontSize = 40;
        //GUI.Label(new Rect(0, 0, 1000, 700), CurrentMessage1, Message);
        //GUI.Label(new Rect(0, 40, 1000, 700), CurrentMessage2, Message);
        //GUI.Label(new Rect(0, 80, 1000, 700), CurrentMessage3, Message);
        //GUI.Label(new Rect(750, 450, 1010, 710), "Ammo = " + Camera.GetComponent<Shooting>().CAmmo, UI);
        //GUI.Label(new Rect(10, 40, 1010, 710), "Health = " + Player.GetComponent<PlayerBehaviour>().Health, UI);
        if (Camera.GetComponent<Shooting>().ReloadCooldown != 0)
        {
            GUI.Label(new Rect(400, 200, 1010, 710), "Reload timer =" + Camera.GetComponent<Shooting>().ReloadCooldown);
        }
        else if (Camera.GetComponent<Shooting>().CAmmo == 0)
        {
            GUI.Label(new Rect(460, 200, 1010, 710), "Reload!");
        }

        //if (Player.GetComponent<PlayerBehaviour>().IsHacking)
        //{
        //    GUI.Label(new Rect(460, 300, 1010, 710), "Tinkering...");
        //}


        GUI.Label(new Rect(0, 0, 1000, 710), UpgradeDescription, Message);
    }
}
