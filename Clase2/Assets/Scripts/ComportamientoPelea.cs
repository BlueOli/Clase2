using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje
{
    public class Arma
    {
        public string nombre;
        public int capacidadDeAtaque;

        public Arma(string nombre, int capacidadDeAtaque)
        {
            this.nombre = nombre;
            this.capacidadDeAtaque = capacidadDeAtaque;
        }
    }

    public string nombre;
    public int vida;
    public int defensa;
    public int fuerza;
    Arma arma;

    public Personaje(string nombre, int vida, int defensa, int fuerza, Arma arma)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.defensa = defensa;
        this.fuerza = fuerza;
        this.arma = arma;
    }

    public void pegar(Personaje personaje1, Personaje personaje2)
    {
        personaje2.vida = personaje2.vida - (personaje1.arma.capacidadDeAtaque + personaje1.fuerza);
        Debug.Log(personaje1.nombre + " le ha pegado a " + personaje2.nombre);
    }
}

public class ComportamientoPelea : MonoBehaviour
{
    Personaje Ryu;
    Personaje Ken;
    Personaje.Arma armaDeRyu;
    Personaje.Arma armaDeKen;

    // Start is called before the first frame update
    void Start()
    {
        armaDeRyu = new Personaje.Arma("Arma de Ryu", 2);
        Ryu = new Personaje("Ryu", 100, 5, 3, armaDeRyu);
        armaDeKen = new Personaje.Arma("Arma de Ken", 3);
        Ken = new Personaje("Ken", 80, 3, 2, armaDeKen);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Ryu.pegar(Ryu, Ken);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Ken.pegar(Ken, Ryu);
        }

        if (Ryu.vida == 0)
        {
            Debug.Log("Vida de Ryu: " + Ryu.vida + "           Vida de Ken: " + Ken.vida);
            Debug.Log("Game Over: Ken Wins");
        }
        else if(Ken.vida == 0){
            Debug.Log("Vida de Ryu: " + Ryu.vida + "           Vida de Ken: " + Ken.vida);
            Debug.Log("Game Over: Ryu Wins");
        }
        else
        {
            Debug.Log("Vida de Ryu: " + Ryu.vida + "           Vida de Ken: " + Ken.vida);
        }

    }
}
