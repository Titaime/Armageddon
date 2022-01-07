using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
   
    
    public Controlador controller;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Función para chocar con objetos físicos (no trigger)
    private void OnCollisionEnter(Collision collision) // collision es el objeto con el que choco
    {
        if (collision.gameObject.CompareTag ("Jefe")) // Pregunto si el objeto tiene el tag Enemigo
        {
            //SceneManager.LoadScene("Gano");
            //Debug.Log("Choqué con un enemigo");
            //Destroy(gameObject);    // Funcion para destruir ESTE objeto


        }
        else if (collision.gameObject.tag == "Pared") // Pregunto si el objeto tiene el tag Pared
        {
            //Debug.Log("Choqué con una pared");
        }
        
    }

    // Función para chocar con objetos no físicos (los trigger)
    void OnTriggerEnter(Collider collision) // collision es el objeto con el que choco
    {
        // 
        if (collision.gameObject.tag == "Moneda") // Pregunto si el objeto tiene el tag Moneda
        {
            //Debug.Log("Choqué con una monedita");
            controller.SumarPunto();            // Llamamos a la función en el controlador
            
            Destroy(collision.gameObject);      // Funcion para destruir el objeto

        }
    }

     

}
