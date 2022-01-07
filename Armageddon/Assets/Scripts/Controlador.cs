// Siempre debería existir un controlador para manejar los parámetros
// globales de nuestro juego

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{

    private Ray ray;
    public Text TextoPuntos;
    public GameObject Ganaste;
    private int puntos = 0;
    public int limitePuntos = 100;

    void Start()
    {
        // Se crea el rayo
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ganaste.SetActive(false);
    }

    void Update()
    {
        // Recibe si se hizo click
        if (Input.GetMouseButtonDown (0)) {
          //Debug.Log ("Mouse hizo click!");

          // Resetea el rayo con la posición del mouse
          ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
          RaycastHit[] hits = Physics.RaycastAll (ray);

          // Revisa los objetos tocados por el rayo
          foreach (RaycastHit hit in hits) {
              if (hit.collider.gameObject.tag == "Enemigo") {

                  // Ejecutamos la función RecibirDano() dentro del script de Enemigo
                  // que se encuentra en el objeto con el que chocó el rayo
                  hit.transform.gameObject.GetComponent<Enemigo>().RecibirDano();
                  //Debug.Log ("Toqué un enemigo");
              }
              if (hit.collider.gameObject.tag == "Pared") {
                  //Debug.Log ("Toqué una pared");
              }
          }
      } 
    }

    public void SumarPunto(){
        puntos += 10;
        TextoPuntos.text = puntos.ToString();
        if(puntos >= limitePuntos){
            Ganaste.SetActive(true);
        }
    }
}
