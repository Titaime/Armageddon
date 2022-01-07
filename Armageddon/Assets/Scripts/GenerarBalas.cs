using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBalas : MonoBehaviour
{

    public GameObject projectile; // Objeto el cual se instanciará muchas veces
    public int velocidadProyectil = 10;
    private Vector3 offset; // Separación del personaje
    public float tiempodis = 2000;
    float tiempoant = 0;
     // Start is called before the first frame update
    void Start()
    {
        tiempoant = Time.time; 

    }


    void Update()
    {
        // Se presiona CTRL, lanza el proyectil
        if (Time.time - tiempoant>tiempodis)
        {
            // Se instancia el objeto projectile en la posición y rotación asignada
            tiempoant = Time.time;
            GameObject clone;
            offset = gameObject.transform.forward;
            clone = Instantiate(projectile, transform.position + offset, transform.rotation);
            Rigidbody bulletRig = clone.GetComponent<Rigidbody>();
            // Se le da al objeto un movimiento y velocidad inicial
            bulletRig.velocity = transform.TransformDirection(Vector3.forward * velocidadProyectil);
        }
    }

}
