using UnityEngine;

public class MiniBehaviours : MonoBehaviour
{

    //getters & setters---------------------------------------------------
    private int health;
    private int maxHealth = 100;

    public int Health
    {
        get { return health; } 
        set
        {
            health = Mathf.Clamp(value, 0, 100);
            Debug.Log("Health Value Changed");
        }
    }

    private int _score = 0;
    public int Score { get { return _score; } }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ternary operators ----------------------------------------------
        // ctrl + k + c to comment many lines
 
        AddPoints(10);

        string message = "";

        message = (_score >= 100) ? "excellent" : "try harder";
        //print(message);

        //switch demo ------------------------------------------------------
        int id = 0;
        string resultSwitch = "";

        switch (id)
        {
            case 0:
                resultSwitch = "OK";
                break;
            case 1:
                resultSwitch = "good";
                break;
            default:
                resultSwitch = "abhorrent";
                break;
        }

    }

    void AddPoints(int points)
    {
        _score += points;
    }
}
