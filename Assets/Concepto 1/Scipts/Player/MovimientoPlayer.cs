using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : UnityEngine.MonoBehaviour {

    CharacterController charC;
    [SerializeField]
    float speed;
    [SerializeField]
    float jump;
    [SerializeField]
    float camerdaSpeed;
    [SerializeField]
    float cameraRotationY;
    public float gravityForce;
    float cameraAngle;
    Camera cameraPlayer;
    float currentGravity;
    public bool groundMode;

    private void Awake()
    {
        charC = GetComponent<CharacterController>();
        cameraPlayer = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        HeadMovement();
        if (groundMode == true)
        {
            PlayerGravity(gravityForce);
            GroundMovement();
        }
        if(groundMode == false)
        {
            PlayerGravity(gravityForce);
            AirMovement();
        }     
    }

    // Movimiento de la camara del jugador
    void HeadMovement()
    {
        float rotX = Input.GetAxis("Mouse X") * camerdaSpeed * Time.deltaTime;
        transform.Rotate(0, rotX, 0);

        float ejeY = Input.GetAxis("Mouse Y") * -camerdaSpeed * Time.deltaTime;
        cameraAngle += ejeY;
        cameraAngle = Mathf.Clamp(cameraAngle, -cameraRotationY, cameraRotationY);
        cameraPlayer.transform.localEulerAngles = new Vector3(cameraAngle, 0, 0);
    }

    // Se encarga del movimiento en tierra del jugador
    void GroundMovement()
    {
        Vector3 movement = new Vector3(0,-currentGravity, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += -transform.right * speed;
        }

        charC.Move(movement * Time.deltaTime);

        if (charC.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentGravity = -jump;
            }
            else
            {
                currentGravity = 0;
            }
        }
    }

    // Se encarga de la gravedad que aplica sobre el pesonaje
    public void PlayerGravity(float gravity)
    {
        currentGravity += gravity * Time.deltaTime;
    }

    // Se encarga del movimiento en el aire
    public void AirMovement()
    {
        Vector3 movement = new Vector3(0, -currentGravity, 0);
        if (Input.GetKey(KeyCode.W))
        {
            currentGravity = 0;
            movement += cameraPlayer.transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentGravity = 0;
            movement += -cameraPlayer.transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentGravity = 0;
            movement += cameraPlayer.transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentGravity = 0;
            movement += -cameraPlayer.transform.right * speed;
        }

        charC.Move(movement * Time.deltaTime);
    }
}
