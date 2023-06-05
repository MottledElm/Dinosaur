using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _IsShooting;
    public float Cooldown = 300f;
    public float CooldownSpeed = 1f;
    public float ReloadCooldown = 0f;
    public float ReloadSpeed = 1f;
    public int CurrentGun = 1;
    public bool IsADS = false;
    public GameObject Gun1;
    public GameObject Gun2;

    public int CAmmo;
    public int CTotalAmmo;
    public float CCooldown;
    public float CReload;
    public int CAmmoCap;
    public int CDamage;

    public class Gun
    {
        public int Ammo;
        public int TotalAmmo;
        public float Cooldown;
        public float Reload;
        public int AmmoCap;
        public int Damage;
    }
    Shooting.Gun Revolver = new Shooting.Gun()
    {
        Ammo = 6,
        TotalAmmo = 999,
        AmmoCap = 6,
        Cooldown = 300f,
        Reload = 1000f,
        Damage = 50,
    };


    Shooting.Gun MachineGun = new Shooting.Gun()
    {
        Ammo = 30,
        TotalAmmo = 9999,
        AmmoCap = 30,
        Cooldown = 50f,
        Reload = 800f,
        Damage = 15,
    };
        

       public List<Shooting.Gun> Guns = new List<Shooting.Gun>()
        {
            
        };

    // Start is called before the first frame update
    void Start()
    {
        Guns.Add(Revolver);
        Guns.Add(MachineGun);
        GameObject.Find("tommygun").SetActive(false);
    }
         
    // Update is called once per frame
    void Update()
    {
        CAmmo = Guns[CurrentGun - 1].Ammo;
        CTotalAmmo = Guns[CurrentGun - 1].TotalAmmo;
        CCooldown = Guns[CurrentGun - 1].Cooldown;
        CReload = Guns[CurrentGun - 1].Reload;
        CAmmoCap = Guns[CurrentGun - 1].AmmoCap;
        CDamage = Guns[CurrentGun - 1].Damage;

        //cooldowns
        Cooldown -= 1 * CooldownSpeed;
        ReloadCooldown -= 1 * ReloadSpeed;

        if (Cooldown <= 0f)
        {
            Cooldown = 0f;
        }

        if (ReloadCooldown <= 0f)
        {
            ReloadCooldown = 0f;
        }

        //shooting


            if (Cooldown == 0f)
            {
                if (ReloadCooldown == 0f)
                {
                    if (Guns[CurrentGun - 1].Ammo > 0)
                    {
                        _IsShooting |= Input.GetKey(KeyCode.Mouse0);
                    }
                }
            }
        

        //switch guns
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (CurrentGun == 1)
            {
                CurrentGun = 2;
                Gun1.SetActive(false);
                Gun2.SetActive(true);
            }
            else
            {
                CurrentGun = 1;
                Gun1.SetActive(true);
                Gun2.SetActive(false);
            }
        }

        //reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Guns[CurrentGun - 1].Ammo != Guns[CurrentGun - 1].AmmoCap)
            {
                ReloadCooldown = Guns[CurrentGun - 1].Reload;
            }
        }

        if (ReloadCooldown == 1)
        {
            if (Guns[CurrentGun-1].TotalAmmo >= Guns[CurrentGun-1].AmmoCap - Guns[CurrentGun - 1].Ammo)
            {
                Guns[CurrentGun - 1].TotalAmmo -= Guns[CurrentGun - 1].AmmoCap - Guns[CurrentGun - 1].Ammo;
                Guns[CurrentGun - 1].Ammo = Guns[CurrentGun - 1].AmmoCap;
            }
            else
            {
                Guns[CurrentGun - 1].Ammo += Guns[CurrentGun - 1].TotalAmmo;
                Guns[CurrentGun - 1].TotalAmmo = 0;
            }
        }

        

        IsADS = false;
        //ADS
        if (Input.GetKey(KeyCode.Mouse1))
        {
            IsADS = true;
            Camera.main.fieldOfView = 40;
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().moveSpeed = 5f;
        }


    }

    void FixedUpdate()
    {
        if (_IsShooting)
        {

            Vector3 spawnPos = this.transform.position + this.transform.forward;
            GameObject newBullet = Instantiate(Bullet, spawnPos, Quaternion.identity);

            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.velocity = this.transform.forward * BulletSpeed;

            Cooldown = Guns[CurrentGun-1].Cooldown;
            Guns[CurrentGun - 1].Ammo -= 1;
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().IsSprinting = false;
        }
        // 8
        _IsShooting = false;
    }
}
