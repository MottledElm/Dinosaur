using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    int damping = 3;
    public float cooldown = 500f;
    public GameObject Bullet;
    public GameObject Player;
    public int BulletSpeed;
    public GameObject Enemy;
    public float MoveTimer = 2000f;
    public float MoveDirectionV;
    public float MoveDirectionH;
    public int MoveSpeed = 2;
    public bool Stunned = false;
    public bool JustMeleed;

    public float Health = 100;
    public int Damage = 10;
    public float ShootOffset = 0;

    public bool IsRoll = false;
    public float MoveSpeedMultiplier = 1;
    public float RollSpeed = 1;
    public float RollDuration = 2;
    public float CurrentRollDuration;

    public int ScanDuration = 1000;
    public int CurrentScanDuration;
    public float CurrentScanDelay;
    public bool IsScan = false;
    public bool BeingScanned = false;
    public Light ScanLight;
    public int ScanType;
    public Material OriginalMat;
    public Material StunnedMat;

    public float MeleeTimer;
    public bool IsMeleed = false;


    private float _vInput;
    private float _hInput;

    // Start is called before the first frame update
    void Start()
    {
        ScanLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Decoy") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Decoy");
        }
        else Player = GameObject.Find("Player");

        cooldown -= 1;

        //Check for smoke screen
        if (!Player.CompareTag("Decoy"))
        {
            if (Player.GetComponent<PlayerBehaviour>().IsSmoke == true)
            {
                ShootOffset = Random.Range(-10, 10);
            }
            else ShootOffset = 0;
        }

        //rotate
        var LookPosition = Player.transform.position - this.transform.position + new Vector3(ShootOffset, ShootOffset, 0);
        LookPosition.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(LookPosition), Time.deltaTime * damping);

        //shoot
        if (cooldown == 0 && !Stunned)
        {
            Vector3 spawnPos = this.transform.position + this.transform.forward;
            GameObject newBullet = Instantiate(Bullet, spawnPos, Quaternion.identity);

            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.velocity = this.transform.forward * BulletSpeed;
            cooldown = 500f;
            newBullet.GetComponent<BulletBehaviour>().Enemy = Enemy;
        }
        if (cooldown < 0)
        {
            cooldown = 0;
        }

        //move
        MoveTimer -= 1;
        if (MoveTimer < 0)
        {
            MoveTimer = 0;
        }

        if (MoveTimer == 0)
        {
            if (!Player.CompareTag("Decoy"))
            {
                MoveDirectionV = Random.Range(-1, 2);
                MoveDirectionH = Random.Range(-1, 2);
                MoveTimer = Random.Range(100f, 1000f);
                if (Random.Range(1, 2) == 1 && !Stunned)
                {
                    MoveSpeed = 2;
                }
                else MoveSpeed = 0;
            }
            else
            {
                MoveDirectionV = 1;
                MoveDirectionH = 0;
                MoveTimer = Random.Range(100f, 1000f);
                MoveSpeed = 1;
            }
        }

        //roll
        if (Random.Range(1,2000) == 1) 
        {
            Roll();
            CurrentRollDuration = RollDuration;
        }
        if (CurrentRollDuration > 0)
        {
            CurrentRollDuration -= 1;
        }
        if (CurrentRollDuration == 0 && IsRoll)
        {
            IsRoll = false;
            
        }

        //die
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        if (!IsRoll)
        {
            _vInput = MoveDirectionV * MoveSpeed;

            _hInput = MoveDirectionH * MoveSpeed;
        }

            this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);

            this.transform.Translate(_hInput * Time.deltaTime, 0, 0);

        //Scan
        if (CurrentScanDuration == 0 && BeingScanned)
        {
            ScanLight.enabled = false;
            this.GetComponent<Renderer>().material = OriginalMat;
            Stunned = false;
            BeingScanned = false;
        }
        else CurrentScanDuration -= 1;

        if (CurrentScanDelay <= 0 && IsScan)
        {
            if (ScanType == 1)
            {
                ScanLight.enabled = true;
                CurrentScanDuration = ScanDuration;
                IsScan = false;
                BeingScanned = true;
            }

            if (ScanType == 2)
            {
                this.GetComponent<Renderer>().material = StunnedMat;
                Stunned = true;
                CurrentScanDuration = ScanDuration;
                IsScan = false;
                BeingScanned = true;
            }
        }
        else CurrentScanDelay -= 1;


        //Melee
        if (MeleeTimer <= 0 && IsMeleed)
        {
            IsMeleed = false;
            Stunned = false;
            this.GetComponent<Renderer>().material = OriginalMat;
        }
        else MeleeTimer -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        JustMeleed = false;
    }
    public void Roll()
    {
        
        CurrentRollDuration = RollDuration;
        IsRoll = true;
        if (Random.Range(1, 3) == 1)
        {
            _hInput = RollSpeed;
        }
        else _hInput = -RollSpeed;
    }

    public void GetScanned(int type)
    {
        CurrentScanDelay = Player.GetComponent<PlayerBehaviour>().ScanDelay * 10;
        IsScan = true;
        ScanType = type;
    }

    public void GetMeleed()
    {
        MeleeTimer = 5;
        Stunned = true;
        IsMeleed = true;
        this.GetComponent<Renderer>().material = StunnedMat;
    }

    


}
