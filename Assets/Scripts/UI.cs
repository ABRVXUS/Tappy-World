using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    void OnGUI()
    {
        //set button width to 1/7th of the screen width to span screen
        //(there are 7 buttons)
        float buttonWidth = (Screen.width / 7);

        //declare buttonStyle
        GUIStyle buttonStyle = new GUIStyle("Button");
        buttonStyle.fontSize = 14;

        //Creating all 7 buttons
        if (GUI.Button(new Rect(0, Screen.height - 150, buttonWidth, 25), "Population", buttonStyle))
        { }
        if (GUI.Button(new Rect(buttonWidth, Screen.height - 150, buttonWidth, 25), "Science/Research", buttonStyle))
        { }
        if (GUI.Button(new Rect(buttonWidth * 2, Screen.height - 150, buttonWidth, 25), "EP", buttonStyle))
        { }
        if (GUI.Button(new Rect(buttonWidth * 3, Screen.height - 150, buttonWidth, 25), "Upgrades", buttonStyle))
        { }
        if (GUI.Button(new Rect(buttonWidth * 4, Screen.height - 150, buttonWidth, 25), "Economy", buttonStyle))
        { }
        if (GUI.Button(new Rect(buttonWidth * 5, Screen.height - 150, buttonWidth, 25), "Timeline/Age", buttonStyle))
        { }
        if (GUI.Button(new Rect(buttonWidth * 6, Screen.height - 150, buttonWidth, 25), "Traits", buttonStyle))
        { }

        //create textFields
        GUI.TextField(new Rect(0, 0, Screen.width, 25), "");
        
    }
}
