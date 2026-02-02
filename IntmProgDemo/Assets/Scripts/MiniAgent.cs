using UnityEngine;

public class MiniAgent: MonoBehaviour
{

    public MiniBehaviours miniExample;

    void Start()
    {

        //getters & setters
        miniExample.Health = 600;

        Debug.Log(miniExample.Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
