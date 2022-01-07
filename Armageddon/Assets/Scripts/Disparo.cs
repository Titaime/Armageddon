using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Preguntamos si se ejecutó el botón de Fire1 (Ctrl o click)
        if (Input.GetButtonDown("Fire1")) {

            // Instanciamos un RaycastHit para obtener la información de 
            // con qué chocó el rayo
            RaycastHit hit;

            // Tiramos el raycast
            if(Physics.Raycast(transform.position + gameObject.transform.forward, transform.forward, out hit, 10f)){

                if(hit.transform.tag == "Enemigo"){
                    // Ejecutamos la función RecibirDano() dentro del script de Enemigo
                    // que se encuentra en el objeto con el que chocó el rayo
                    hit.transform.gameObject.GetComponent<Enemigo>().RecibirDano();

                    // Dibujamos el rayo (sólo para pruebas)
                    Debug.DrawRay(transform.position, transform.forward * 10f, Color.green);
                }
                else{
                    Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
                }

                
            }
        }
    }
}
