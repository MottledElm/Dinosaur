using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickerBehaviour : MonoBehaviour
{

    public float TickerTimer = 0;
    public GameObject SmokeBomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TickerTimer >= 10)
        {
            if (GameObject.Find("Player").GetComponent<PlayerBehaviour>().HackType == 2)
            {
                GameObject newSmokeBomb = Instantiate(SmokeBomb);
                newSmokeBomb.transform.position = this.transform.position;
            }
                Destroy(this.gameObject);
            
        }
        else TickerTimer += Time.deltaTime;
    }
}
