using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : MonoBehaviour
{
    public float SmokeTimer;
    public ParticleSystem Smoke;
    // Start is called before the first frame update
    void Start()
    {
        Smoke.Play();
    }

    // Update is called once per frame
    void Update()
    {

        
            
            Collider[] Smoked = Physics.OverlapSphere(this.transform.position, 9);
                    foreach (Collider hit in Smoked)
                    {
                        if (hit.CompareTag("Enemy"))
                        {
                            hit.GetComponent<EnemyBehaviour>().ShootOffset = Random.Range(-40, 40);
                        }
                    }

            Destroy(this.gameObject,10f);

        
        
    }
}
