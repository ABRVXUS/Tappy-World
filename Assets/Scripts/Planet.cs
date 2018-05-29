using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Planet : MonoBehaviour
{
    //declare variables for points and other planet based data
    public float mCount, fCount, ep, cp, sp, territoryNum, time, birth, death;
    public float mult = 1;

	// Use this for initialization
	void Start()
    {
        Load();
    }

    //when mouse is clicked
    void OnMouseDown()
    {
        int temp;
        bool person;
        //declare renderer for changing highlighted color to red
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;

        temp = UnityEngine.Random.Range(1, 11);

        if (temp == 0)
        {
            fCount += (fCount * mult);
        }
        else
        {
            mCount += (mCount * mult);
        }
    }

    //when mouse released
    void OnMouseUp()
    {
        //declare renderer for changing highlighted color and set to white
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Color.white;
    }

    //method to create/write to save game file at persistent data path
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlanetInfo.jeff");

        PlanetData data = new PlanetData(mCount, fCount, ep, cp, sp, territoryNum, time, mult);

        bf.Serialize(file, data);
        file.Close();
    }

    //method to load save file and retrieve saved data
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

//Serializable class containing variables to be written in save file
[Serializable]
class PlanetData
{
    public float mCount, fCount, ep, cp, sp, pop, territoryNum, time, mult;

    //retrieves variables to be stored in file
    public PlanetData(float mC, float fC, float ePoint, float cPoint, float sPoint, float terrNum, float gameTime, float multiplier)
    {
        ep = ePoint;
        cp = cPoint;
        sp = sPoint;
        territoryNum = terrNum;
        time = gameTime;
        mult = multiplier;
        mCount = mC;
        fCount = fC;
    }
}
