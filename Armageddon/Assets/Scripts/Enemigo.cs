using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 1;

    // Se llama una vez al instanciarse el objeto
    void Start()
    {
        
    }

    // Se llama una vez por frame
    void Update()
    {
        
    }

    // Cuando chocamos con un objeto físico...
    void OnCollisionEnter(Collision collision) // collision es el objeto con el que choco
    {
        if (collision.gameObject.tag == "Bala") // Pregunto si el objeto tiene el tag Enemigo
        {
            RecibirDano();
            Destroy(collision.gameObject);
        }
        
        
        
    }

    // Función para recibir un punto de daño y revisar si la
    // vida del enemigo llegó a 0
    public void RecibirDano(){
        vida -= 1;
        if(vida == 0){
            
            Destroy(gameObject);    // Funcion para destruir ESTE objeto
        }
    }
}
