using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    bool isItWeekday;
    bool isItRaining;
    bool needToGoOutside;
    bool haveZoomInterview;
    bool isWorkoutDay = true;


    void Start()
    {
        ConditionMap();
    }

    // otherwise known as flow control
    void ConditionMap()
    {
        // it is a weekday
        if (isItWeekday)
        {
            Debug.Log("Get up at 6:30");
            // it is raining
            if (isItRaining == true)
            {
                Debug.Log("Wear a raincoat");
            }
            // it is not raining
            // else, isItRaining == false
            else
            {
                Debug.Log("Don't wear a raincoat");
            }
        }
        // it is not a weekday
        // else, isItWeekday == false
        else
        {
            Debug.Log("Get up at 8:30");
            // I need to go outside
            if (needToGoOutside == true)
            {
                Debug.Log("Wear our street clothes");
            }
            // else if haveZoomInterview == true
            else if (haveZoomInterview)
            {
                Debug.Log("Put on a tie");
            }
            else if (isWorkoutDay)
            {
                Debug.Log("Put on a stretchy headband");
            }
            // I don't need to go outside
            // else, needToGoOutside == false
            else
            {
                Debug.Log("Stay in PJs");
            }
        }
    }

}
