using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public int StartLevel;
    public int Level;
    public GameObject Controller;
    public GameObject Enemy;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Level != Controller.GetComponent<ArenaControl>().CurrentLevel)
        {
            Level = Controller.GetComponent<ArenaControl>().CurrentLevel;
            if (Level >= StartLevel)
            {
                GameObject newEnemy = Instantiate(Enemy, this.transform.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyBehaviour>().Player = GameObject.Find("Player");
            }
        }
    }
}
