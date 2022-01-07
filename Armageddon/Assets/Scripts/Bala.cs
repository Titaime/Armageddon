// Script pequeño para un objeto que se instancia muchas veces

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    void Start()
    {
        // Elimina la bala en 5 segundos después de creada
        Object.Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        
    }

    // Al chocar con algo se destruye inmediatamente
    void OnCollisionEnter(Collision collision) 
    {
        Object.Destroy(gameObject);
    }
}
