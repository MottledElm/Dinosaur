using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{

    public int Level;
    public GameObject Controller;
    public GameObject Barrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Level != Controller.GetComponent<ArenaControl>().CurrentLevel)
        {
            Level = Controller.GetComponent<ArenaControl>().CurrentLevel;
            if (transform.childCount == 0)
            {
                GameObject newBarrel = Instantiate(Barrel, this.transform);
                newBarrel.transform.position = this.transform.position;
                newBarrel.transform.localScale = new Vector3(2,2,2);
            }
        }
    }
}
