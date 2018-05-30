using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

public class Clock : MonoBehaviour
{
    //create variable to store days and a timer
    public float totalDays;
    Timer timer;
    
    //retrieve and store total game days in save
    public Clock(float daysPast)
    {
        totalDays = daysPast;
    }

    // Use this for initialization
    void Start()
    {
        //instantiate timer (1 game day = 2 minutes). calls AddDay and restarts
        timer = new Timer(TimeSpan.FromMinutes(2).TotalMilliseconds);
        timer.AutoReset = true;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(AddDay);
        timer.Start();
    }

    //add one day
    private void AddDay(object sender, EventArgs e)
    {
        totalDays++;
    }

    //stop game clock
    public void StopClock()
    {
        timer.Stop();
    }

    //return total game days for save file
    public float getDays()
    {
        return totalDays;
    }
}
