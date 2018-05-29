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

	// Use this for initialization
	void Start()
    {
        birth = 1;

        Load();
    }

    //when mouse is clicked
    void OnMouseDown()
    {
        int temp;

        //declare renderer for changing highlighted color to red
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;

        temp = (int)UnityEngine.Random.Range(0, 2);

        if (temp == 1)
        {
            fCount = fCount + birth;
        }
        else
        {
            mCount = mCount + birth;
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

        PlanetData data = new PlanetData(mCount, fCount, ep, cp, sp, territoryNum, time, birth, death);

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
    public float mCount, fCount, ep, cp, sp, pop, territoryNum, time, birth, death;

    //retrieves variables to be stored in file
    public PlanetData(float mC, float fC, float ePoint, float cPoint, float sPoint, float terrNum, float gameTime, float bRate, float dRate)
    {
        ep = ePoint;
        cp = cPoint;
        sp = sPoint;
        territoryNum = terrNum;
        time = gameTime;
        mCount = mC;
        fCount = fC;
        birth = bRate;
        death = dRate;
    }
}
