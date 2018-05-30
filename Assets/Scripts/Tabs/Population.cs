using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    float pop;

	public Population(float mCount, float fCount)
    {
        pop = mCount + fCount;
    }
	
    public float PopCleanse()
    {
        float max, deathCount;

        max = (float)(pop * 0.15);

        deathCount = (float)UnityEngine.Random.Range(0, max);

        return deathCount;
    }

    public float PopIncrease(float gender)
    {
        float max, birthCount;

        max = (float)(gender * .2);

        birthCount = (float)UnityEngine.Random.Range(0, max);

        return birthCount;
    }
}
