using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaControl : MonoBehaviour
{
    public int CurrentLevel = 0;
    public float SkillPoints = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().Health = 100;
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().transform.position = this.transform.position;
            if (CurrentLevel != 0)
            {
                GameObject.Find("Canvas").GetComponent<PauseMenu>().UpgradeMenu();
            }
            SkillPoints += 1;
            CurrentLevel += 1;
        }
    }
}
