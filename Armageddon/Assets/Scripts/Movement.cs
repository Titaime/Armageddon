// Script basado en https://docs.unity3d.com/ScriptReference/CharactermoveController.Move.html
// Práctica de Input, movimiento y Spherecast
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Camera mainCamera;
    public int alturaCamara = 35;
    public int distanciaAtras = 0;
    private CharacterController moveController;
    //private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    

    private void Start()
    {
        // Se crea automáticamente el CharacterController
        moveController = gameObject.AddComponent<CharacterController>();
        //controller = gameObject.AddComponent<CharacterController>();
        //mainCamera = Camera.main;
        moveController.center = new Vector3(0, 0.8f, 0);
    }

    void Update()
    {
        // Con el Spherecast reviso si algo me toca desde el frente
        if(TocaFrente("Enemigo")){
            Debug.Log("Me toco desde el frente");
        }

        // Preguntamos si el objeto está tocando el piso
        groundedPlayer = moveController.isGrounded; // IsGrounded();
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(groundedPlayer){
            moveController.Move(move * Time.deltaTime * playerSpeed);   
        }
        else{
            // En caso de que estemos en el aire, la velocidad se divide entre 2
            moveController.Move(move * Time.deltaTime * (playerSpeed/2)); 
        }
        

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Si se presiona el botón de saltar y estamos en el piso...
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // Saltamos agregando una fuerza en y
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -6.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        moveController.Move(playerVelocity * Time.deltaTime);

        // Mueve la cámara hacia nosotros
        //MoveCamera();
    }

    //void MoveCamera()
    //{
    //    // Mueve la cámara hacia nuestra posición pero con un extra
    //    // en la altura y hacia atrás
    //    mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y + alturaCamara, transform.position.z - distanciaAtras);
    //}

    // Para saber si un objeto con un tag en específico
    // nos está tocando desde el frente
    public bool TocaFrente(string tagObjeto){
        // Cual Layer revisaremos
        LayerMask mask = LayerMask.GetMask("Default"); 
        
        // Donde se guardará la información del objeto que toquemos
        RaycastHit hit;

        // Se realiza el Spherecast
        if(Physics.SphereCast( transform.position, 0.3f,  transform.forward, out hit, 0.7f, mask )){
            if(hit.transform.tag == tagObjeto){
                   return true;
            }
            else{
                return false;
            }
        }

        return false;

        
    }

    // Para saber si estamos tocando el piso...
    public bool IsGrounded(){
        Debug.Log("IsGrounded");
        LayerMask mask = LayerMask.GetMask("Default");
        
        RaycastHit hit;
        return Physics.SphereCast(
            transform.position,
            0.1f,
            Vector3.down,
            out hit,
            0.5f,
            mask
        );
    }
}