using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Pollution = 5;
    public string CurrentMessage1;
    public string CurrentMessage2;
    public string CurrentMessage3;
    public string UpgradeDescription;
    private GUIStyle Message = new GUIStyle();
    private GUIStyle UI = new GUIStyle();
    public GameObject Camera;
    public GameObject Player;
    public GameObject ArenaControl;

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
    }

    private void OnGUI()
    {
        Message.fontSize = 40;
        Message.alignment = TextAnchor.MiddleCenter;
        UI.fontSize = 40;
        GUI.Label(new Rect(0, 0, 1000, 700), CurrentMessage1, Message);
        GUI.Label(new Rect(0, 40, 1000, 700), CurrentMessage2, Message);
        GUI.Label(new Rect(0, 80, 1000, 700), CurrentMessage3, Message);
        GUI.Label(new Rect(750, 400, 1010, 710), "Ammo = " + Camera.GetComponent<Shooting>().CAmmo, UI);
        GUI.Label(new Rect(10, 40, 1010, 710), "Health = " + Player.GetComponent<PlayerBehaviour>().Health, UI);
        if (Camera.GetComponent<Shooting>().ReloadCooldown != 0)
        {
            GUI.Label(new Rect(400, 200, 1010, 710), "Reload timer =" + Camera.GetComponent<Shooting>().ReloadCooldown);
        }
        else if (Camera.GetComponent<Shooting>().CAmmo == 0)
        {
            GUI.Label(new Rect(460, 200, 1010, 710), "Reload!");
        }

        if (Player.GetComponent<PlayerBehaviour>().IsHacking)
        {
            GUI.Label(new Rect(460, 300, 1010, 710), "Tinkering...");
        }


        GUI.Label(new Rect(0, 0, 1000, 710), UpgradeDescription, Message);
    }
}
