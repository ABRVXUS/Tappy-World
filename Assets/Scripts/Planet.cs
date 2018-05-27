using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Planet : MonoBehaviour
{
    //declare variables for points and other planet based data
    public float ep, cp, sp, pop, territoryNum, time;
    public float mult = 1;

	// Use this for initialization
	void Start ()
    {

    }

    //when mouse is clicked
    void OnMouseDown()
    {
        //declare renderer for changing highlighted color to red
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;

        pop += (1*mult);
    }

    //when mouse released
    void OnMouseUp()
    {
        //declare renderer for changing highlighted color and set to white
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Color.white;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlanetInfo.jeff");

        PlanetData data = new PlanetData(ep, cp, sp, pop, territoryNum, time, mult);

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/PlanetInfo.jeff"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlanetInfo.jeff", FileMode.Open);

            PlanetData data = (PlanetData)bf.Deserialize(file);
            file.Close();

            //assign variables
            ep = data.ep;
        }
    }
}

[Serializable]
class PlanetData
{
    public float ep, cp, sp, pop, territoryNum, time, mult;

    public PlanetData(float ePoint, float cPoint, float sPoint, float population, float terrNum, float gameTime, float multiplier)
    {
        ep = ePoint;
        cp = cPoint;
        sp = sPoint;
        pop = population;
        territoryNum = terrNum;
        time = gameTime;
        mult = multiplier;
    }
}
