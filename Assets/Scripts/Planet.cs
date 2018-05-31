using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Planet : MonoBehaviour
{
    //declare variables for points and other planet based data
    public float mCount, fCount, ep, cp, sp, territoryNum, days, clickRate;
    public Clock clock;

	// Use this for initialization
	void Start()
    {
        //make clickRate 1 by default. Instantiate clock the way that makes Unity happy
        clickRate = 1;
        clock = FindObjectOfType(typeof(Clock)) as Clock;

        Load();

        //pass saved days to Clock
        clock.SetDays(days);
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
            fCount = fCount + clickRate;
        }
        else
        {
            mCount = mCount + clickRate;
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
        //retrive total days from game clock class
        days = clock.getDays();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlanetInfo.jeff");

        PlanetData data = new PlanetData(mCount, fCount, ep, cp, sp, territoryNum, days, clickRate);

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
            cp = data.cp;
            sp = data.sp;
            territoryNum = data.territoryNum;
            days = data.days;
            mCount = data.mCount;
            fCount = data.fCount;
            clickRate = data.clickRate;
        }
    }
}

//Serializable class containing variables to be written in save file
[Serializable]
class PlanetData
{
    public float mCount, fCount, ep, cp, sp, territoryNum, days, clickRate;

    //retrieves variables to be stored in file
    public PlanetData(float mC, float fC, float ePoint, float cPoint, float sPoint, float terrNum, float gamedays, float clickAdd)
    {
        ep = ePoint;
        cp = cPoint;
        sp = sPoint;
        territoryNum = terrNum;
        days = gamedays;
        mCount = mC;
        fCount = fC;
        clickRate = clickAdd;
    }
}
