using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    public bool Interacting = false;
    public GameObject Enemy;
    public GameObject Gun;
    public string InteractionMessage1;
    public string InteractionMessage2;
    public string InteractionMessage3;
    public void Interact()
    {
        
        GameObject.Find("Controller").GetComponent<GameController>().CurrentMessage1 = InteractionMessage1;
        GameObject.Find("Controller").GetComponent<GameController>().CurrentMessage2 = InteractionMessage2;
        GameObject.Find("Controller").GetComponent<GameController>().CurrentMessage3 = InteractionMessage3;
        
        Interacting = true;
    }
    void Update ()
    {
        if (Interacting == true && Input.anyKeyDown)
            {
            Interacting = false;
            GameObject newEnemy = Instantiate(Enemy, this.transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyBehaviour>().BulletSpeed = 10;
            newEnemy.GetComponent<EnemyBehaviour>().Player = GameObject.Find("Player");
            GameObject newGun = Instantiate(Gun, new Vector3(2, 0.5f, 0), Quaternion.identity);
            
            Destroy(this.gameObject);
            }
    }
}