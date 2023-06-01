using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Movement
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public bool IsSprinting = false;
    public float MoveSpeedMultiplier = 1;

    //Melee
    public float MeleeRange = 2;
    public int MeleeType = 0;
    public int MeleeDamage;
    public int MeleeKnockback;
    public int MeleeAngleBetweenRays;
    public int MeleeRayCount;
    public int MeleeAngle;
    public float MeleeCharge;
    public ParticleSystem MeleeChargeEffect;
    public ParticleSystem MeleeEffect;

    //Combat
    public float Health = 100f;

    //Roll
    public bool IsRoll = false;
    public float RollSpeed = 1;
    private float CurrentRollSpeed;
    public float RollDuration = 2;
    private float CurrentRollDuration;

    //Abilities
    public bool IsSmoke = false;
    public float SmokeDuration = 0f;
    public float SmokeCooldown = 0f;

    //Scan
    public int ScanType = 0;
    public float ScanAngle = 90f;
    public float ScanRange = 10f;
    public int rayCount = 40;
    public float ScanDelay;
    public ParticleSystem ScanEffect;

    //Hack
    public int HackType = 0;
    public float HackTimer;
    public Coroutine HackCoroutine;
    private float TickerPlacement;
    public GameObject Ticker;
    public bool CanTicker;
    public GameObject SmokeBomb;
    public bool CanSmoke;
    public bool IsHacking = false;
    


    private float _vInput;

    private float _hInput;
    private float _lookInput;
    private float DistanceToGround = 1f;
    public ParticleSystem SmokeScreen;
    public GameObject Controller;

    public Rigidbody Rigidbody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.1f);
    }
    // Update is called once per frame
    void Update()
    {

        if (!IsRoll)
        {
            _vInput = Input.GetAxis("Vertical") * moveSpeed;

            _hInput = Input.GetAxis("Horizontal") * moveSpeed;
        }

        _lookInput = Input.GetAxis("Mouse X") * rotateSpeed;

        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime * (MoveSpeedMultiplier + CurrentRollSpeed));

        this.transform.Translate(_hInput * Time.deltaTime * (MoveSpeedMultiplier + CurrentRollSpeed), 0, 0);

        this.transform.Rotate(Vector3.up * _lookInput * Time.deltaTime);

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rigidbody.AddForce(new Vector3(0, 400, 0));
        }

        //ability 1
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (SmokeCooldown == 0)

            {
                IsSmoke = true;
                SmokeScreen.Play();
                Controller.GetComponent<GameController>().Pollution += 1;
                
            }
        }

                if (IsSmoke)
                {
                    if (SmokeDuration == 2000f)
                    {
                        IsSmoke = false;
                        SmokeScreen.Stop();
                        SmokeCooldown = 10000f;
                    }
                    else SmokeDuration += 1;
                }
            
        
        SmokeCooldown -= 1;
        if (SmokeCooldown <= 0)
        {
            SmokeCooldown = 0;
        }



        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IsSprinting =! IsSprinting;
        }

        if (IsSprinting)
        {
            moveSpeed = 15f;
            if (Input.GetAxis("Vertical") == 0)
            {
                IsSprinting = false;
            }
            Camera.main.fieldOfView = 80;
        }
        else
        {
            
            if (GameObject.Find("Main Camera").GetComponent<Shooting>().IsADS == false)
            {
                Camera.main.fieldOfView = 60;
                moveSpeed = 10f;
            }
        }

        //melee
        if (Input.GetKeyUp(KeyCode.V))
        {
            Melee();
            MeleeCharge = 0;
            MeleeChargeEffect.Stop();
            MeleeEffect.Play();
        }



        if (MeleeType == 1)
        {
            MeleeDamage = 25;
        }
        else MeleeDamage = 50;

        if (MeleeType == 2 && MeleeCharge < 3)
        {
            MeleeAngleBetweenRays = 8;
            MeleeAngle = 60;
            MeleeRange = 5;
            MeleeKnockback = 10000;
            if (Input.GetKey(KeyCode.V))
            {
                MeleeCharge += Time.deltaTime;
                
            }
            else MeleeCharge = 0;
         
        }
        else
        {
            MeleeAngleBetweenRays = 4;
            MeleeAngle = 4;
            MeleeRange = 2;
            MeleeKnockback = 10000;
        }

        if (MeleeCharge >= 1)
        {
            MeleeAngleBetweenRays = 4;
            MeleeAngle = 4;
            MeleeRange = 2;
            MeleeKnockback = 100000;
            if (!MeleeChargeEffect.isPlaying)
            {
                MeleeChargeEffect.Play();
            }
        }

        //Scan
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (ScanType == 2)
            {
                ScanRange = 20f;
            }
            else ScanRange = 10f;

            if (ScanType == 1)
            {
                ScanAngle = 360;
            }
            else ScanAngle = 90;
            
            Scan();
            Debug.Log("Scan");
            ScanEffect.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            MeleeType = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            MeleeType = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            MeleeType = 2;
        }

        //roll
        if (Input.GetKeyDown(KeyCode.LeftControl) && !IsRoll)
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
            CurrentRollSpeed = 0;
        }

        //hack
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HackCoroutine = StartCoroutine(Hack());
        }

        if (Input.GetKey(KeyCode.Alpha2) && HackType >= 1)
        {
            TickerPlacement += Time.deltaTime;
        }
        else
        {
            TickerPlacement = 0;
            CanTicker = true;
        }

        if (TickerPlacement >= 1 && CanTicker)
        {
            GameObject newTicker = Instantiate(Ticker);
            newTicker.transform.position = this.transform.position + transform.forward * 2;
            CanTicker = false;
        }

        if (Input.anyKeyDown && HackCoroutine != null && !Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopCoroutine(HackCoroutine);
            HackCoroutine = null;
            Debug.Log("Stop");
        }
    }

    private void LateUpdate()
    {
        //death
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //melee method
    void Melee()
    {
        Vector3 coneDirectionM = transform.forward;

        float angleBetweenRaysM = MeleeAngleBetweenRays;

        Vector3 startDirectionM = Quaternion.AngleAxis(-MeleeAngle / 2f, transform.up) * coneDirectionM;

        for (int i = 0; i < 15; i++)
        {
            Vector3 rayDirectionM = Quaternion.AngleAxis(i * angleBetweenRaysM, transform.up) * startDirectionM;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirectionM, out hit, MeleeRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (hit.collider.GetComponent<EnemyBehaviour>().JustMeleed == false)
                    {
                        hit.collider.GetComponent<EnemyBehaviour>().Health -= MeleeDamage;
                        hit.collider.GetComponent<Rigidbody>().AddForce(transform.forward * MeleeKnockback);
                        hit.collider.GetComponent<EnemyBehaviour>().JustMeleed = true;
                        if (MeleeType == 1||MeleeCharge >=3)
                        {
                            hit.collider.GetComponent<EnemyBehaviour>().GetMeleed();
                        }
                    }
                }
            }
            Debug.DrawRay(transform.position, rayDirectionM * MeleeRange, Color.red, 10f);
        }
                GameObject.Find("Main Camera").GetComponent<Shooting>().Cooldown = 700;
 

        
    }

    //scan method
    void Scan()
    {for (float l = -1; l <= 1; l += 0.01f)
        {
            Vector3 coneDirection = transform.forward + new Vector3(0, l, 0);

            float angleBetweenRays = ScanAngle / (rayCount - 1);

            Vector3 startDirection = Quaternion.AngleAxis(-ScanAngle / 2f, transform.up) * coneDirection;

            for (int i = 0; i < rayCount; i++)
            {
                Vector3 rayDirection = Quaternion.AngleAxis(i * angleBetweenRays, transform.up) * startDirection;

                RaycastHit[] hits = Physics.RaycastAll(transform.position, rayDirection, ScanRange);
                foreach (RaycastHit hit in hits){


                    if (hit.collider.CompareTag("Interactable"))
                    {
                        ScanDelay = hit.distance;
                        
                        {
                            hit.collider.GetComponent<ObjectInteraction>().GetScanned();
                        }
                    }

                    
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            hit.collider.GetComponent<EnemyBehaviour>().GetScanned(ScanType);
                        }
                    
                   
                }

                Debug.DrawRay(transform.position, rayDirection * ScanRange, Color.red, 5f);
            }
        }
    }

    //roll method
    public void Roll()
    {
        CurrentRollSpeed = RollSpeed;
        CurrentRollDuration = RollDuration;
        IsRoll = true;
        
    }


    //hack method
    IEnumerator Hack()
    {
        IsHacking = true;
        Debug.Log("Coroutine Running");
        Ray HackRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2,0));
        RaycastHit hit;

        if (Physics.Raycast(HackRay, out hit))
        {
            if (hit.distance < 4)
            {
                yield return new WaitForSeconds(HackTimer);
                
                   GameObject hitObject = hit.collider.gameObject;
                    if (hitObject.gameObject.GetComponent<ExplodingBarrel>() != null)
                    {
                        {
                            hitObject.gameObject.GetComponent<ExplodingBarrel>().Explode();
                        }
                    }
                IsHacking = false;
                
                
                
            }
        }
    }

    

}
