﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    int comboCount;
    float timeFromLastNote;
    float avgTime;
    bool beatHit;
    public float bpm;
    //Allows for a range in time that can vary based on value specified
    public float extraTimeBuffer;

    //Property for beatHit
    public bool BeatHit
    {
        get { return beatHit; }
        set { beatHit = value; }
    }

    //Getter for comboCount
    public int Combo
    {
        get { return comboCount; }
    }

	// Use this for initialization
	void Start ()
    {
        comboCount = 0;
        timeFromLastNote = 0.0f;
        avgTime = 60.0f / bpm;
        beatHit = false;
        Debug.Log(avgTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        beatHit = false;
        timeFromLastNote += Time.deltaTime;
        
        //Temp to test combos
        if (Input.anyKeyDown)
        {
            beatHit = true;
        }

        //Checks to see if the user made the combo
        checkCombo();
	}

    //Checks to see if the combo needs to be updated
    void checkCombo()
    {
        //Check if missed note
        if(timeFromLastNote > avgTime + extraTimeBuffer)
        {
            //Lose combo and reset timeFromLastNote
            comboCount = 0;
            timeFromLastNote = 0.0f;
            Debug.Log("lost combo");
        }
        else if(beatHit == true && (timeFromLastNote >= avgTime - extraTimeBuffer && timeFromLastNote <= avgTime + extraTimeBuffer))
        {
            //Increase combo and reset timeFromLastNote
            comboCount++;
            timeFromLastNote = 0.0f;

            //Display the combo if greater than 1
            if(comboCount > 1)
            {
                Debug.Log("Combo + " + comboCount);  //temporary log until UI is in place
            }
        }
    }
}
