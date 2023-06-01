using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    public ParticleSystem Explosion;
    public ParticleSystem Fuse;
    public int Radius;
    public float ExplosionTimer;
    public bool IsArmed = false;
    public Material Armed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ExplosionTimer > 0)
        {
            ExplosionTimer -= 1;
        }

        if (ExplosionTimer == 0 && IsArmed)
        {
            Explosion.Play();
            Fuse.Stop();
            ActuallyExplode();

            Destroy(this.gameObject,0.2f);
            IsArmed = false;
        }
    }

    public void Explode()
    {
        ExplosionTimer = 1000;
        IsArmed = true;
        Fuse.Play();
        this.GetComponent<Renderer>().material = Armed;
    }

    public void ActuallyExplode()
    {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5);

            foreach (Collider collider in colliders)
            { 
                if (collider.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject);
                }

                if (collider.CompareTag("Player"))
                {
                    collider.GetComponent<PlayerBehaviour>().Health -= 30f;
                }
            }
    }
}
