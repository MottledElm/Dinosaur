using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float OnScreenDelay = 3f;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, OnScreenDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            collision.gameObject.GetComponent<EnemyBehaviour>().Health -= GameObject.Find("Main Camera").GetComponent<Shooting>().CDamage;
            
        }
        if (collision.gameObject.name == "Player" && Enemy != null)
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().Health -= Enemy.GetComponent<EnemyBehaviour>().Damage;
        }

        Destroy(this.gameObject);
    }
}
