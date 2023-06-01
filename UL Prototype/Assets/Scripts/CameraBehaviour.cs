using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.UI;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;





    private float xRotationCamera = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (GameObject.Find("OilEffect") != null)
        {
            GameObject.Find("OilEffect").GetComponent<RawImage>().CrossFadeAlpha(0f, 0f, true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotationCamera -= mouseY;
        xRotationCamera = Mathf.Clamp(xRotationCamera, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotationCamera, 0f, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);

        if (GameObject.Find("Player").GetComponent<PlayerBehaviour>().Health <= 20)
        {

            GameObject.Find("OilEffect").GetComponent<RawImage>().CrossFadeAlpha(1f, 1, false);
        }
    }

}