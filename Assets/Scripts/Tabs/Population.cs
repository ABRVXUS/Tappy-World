using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    float pop;
    private string txt;

    void Start()
    {
        pop = Planet.population;
        txt = string.Format("Population: {0}", pop);
    }
	
    //method for finding how many people are going to die
    public float PopCleanse()
    {
        float max, deathCount;

        max = (float)(pop * 0.15);

        deathCount = (float)UnityEngine.Random.Range(0, max);

        return deathCount;
    }

    //method for finding how many people are going to 
    public float PopIncrease(float gender)
    {
        float max, birthCount;

        max = (float)(gender * .2);

        birthCount = (float)UnityEngine.Random.Range(0, max);

        return birthCount;
    }

    public void GUI()
    {
        GameObject.Find("PanelText").GetComponent<Text>().text = txt;
    }
}
