using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;

public class ItemTienda
{
    public string nombre;
    public int costo;
    
    public ItemTienda(string nombre, int costo)
    {
        this.nombre = nombre;
        this.costo = costo;
    }
}

public class ComportamientoTienda : MonoBehaviour
{
    public string RandomString(int size, bool lowerCase)
    {
        var builder = new StringBuilder(size);

        // Unicode/ASCII Letters are divided into two blocks
        // (Letters 65–90 / 97–122):
        // The first group containing the uppercase letters and
        // the second group containing the lowercase.  

        // char is a single Unicode character  
        char offset = lowerCase ? 'a' : 'A';
        const int lettersOffset = 26; // A...Z or a..z: length=26  

        for (var i = 0; i < size; i++)
        {
            var @char = (char)Random.Range(offset, offset + lettersOffset);
            builder.Append(@char);
        }

        return lowerCase ? builder.ToString().ToLower() : builder.ToString();
    }

    Dictionary<string, int> diccionario = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<10000; i++)
        {
            diccionario.Add(RandomString(10, false), Random.Range(1, 1000));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<string, int> diccionario in diccionario.OrderBy(diccionario => diccionario.Value))
        {
            Debug.Log(diccionario.Key + "---- " + diccionario.Value + " pesos");
        }
    }
}
