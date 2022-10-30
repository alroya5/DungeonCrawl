using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatorController : MonoBehaviour
{
    public Text raza, clase, genero;
    public GameObject Canvas;
    public GameObject Humano, Enano, Elfo;
    GameObject sprite;
    public Valores valores;
   

    string[] lista_raza ={"Humano", "Elfo", "Enano" };
    string[] lista_clase = { "Caballero", "Bárbaro", "Arquero" };
    string[] lista_genero = { "Masculino","Femenino" };
    int cont1 = 0, cont2 = 0, cont3 = 0;

    void Start()
    {
        valores = FindObjectOfType<Valores>();
        actualizador();
        actualizadorSprite();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Derecha1()
    {
        cont1++;
        if (cont1 > 2)
        {
            cont1 = 0;
        }
        actualizador();
        actualizadorSprite();
    }
    public void Izquierda1()
    {
        cont1--;
        if (cont1 < 0)
        {
            cont1 = 2;
        }
        actualizador();
        actualizadorSprite();
    }
    public void Derecha2()
    {
        cont2++;
        if (cont2 > 2)
        {
            cont2 = 0;
        }
        actualizador();
    }
    public void Izquierda2()
    {
        cont2--;
        if (cont2 < 0)
        {
            cont2 = 2;
        }
        actualizador();
    }
    public void Derecha3()
    {
        cont3++;
        if (cont3 > 1)
        {
            cont3 = 0;
        }
        actualizador();
    }
    public void Izquierda3()
    {
        cont3--;
        if (cont3 < 0)
        {
            cont3 = 1;
        }
        actualizador();
    }

    private void actualizador()
    {
        raza.text = lista_raza[cont1];
        clase.text = lista_clase[cont2];
        genero.text = lista_genero[cont3];
    }
    private void actualizadorSprite()
    {
        Destroy(sprite);
        if (cont1 == 0)
        {
            sprite = Instantiate(Humano);
            valores.spriteRaza = 0;
        }
        else if (cont1 == 1)
        {
            sprite = Instantiate(Elfo);
            valores.spriteRaza = 1;
        }
        else if (cont1 == 2)
        {
            sprite = Instantiate(Enano);
            valores.spriteRaza = 2;
        }
        sprite.transform.position = new Vector3(0, -2, -1);
    }

    public void listo()
    {
        SceneManager.LoadScene("Combate");
    }
}
