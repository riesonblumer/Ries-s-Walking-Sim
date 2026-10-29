using UnityEngine;

public class OperatorsExampleScript : MonoBehaviour
{
    string nameOfMe = "Ries";

    bool math1 = 3 < 5;
    bool math2 = 1000 == 5;
    bool math3 = 10f <= 10f;

    // || OR
    bool math5 = (8 > 6) || (10 > 1000);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, my name is " + nameOfMe);
        Debug.Log("Math1: " + math1);
        //Debug.Log("Math2: " + math2);
        //Debug.Log("Math3: " + math3);

        // && AND
        bool math4 = math2 && math3;
        //Debug.Log("Math4: " + math4);
        //Debug.Log("Math5: " + math5);

        // ! NOT
        bool math6 = !math1;
        //Debug.Log("Math6: " + math6);
    }
}