using UnityEngine;

public class DemoManager : MonoBehaviour //right click --> go to definition to see MonoBehaviour source code
{
    public float timer = 0; //all can access
    private float timerPriv = 0; //only self can access
    protected float timerProtected = 0; //only children can access
    float timerDefault = 0; //default is private

    public enum carType { Toyota, Ford, Subaru}
    public carType car = carType.Toyota;

    float playerHP = 10;
    string playerName = "Jerry";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("playerHP", playerHP);
        PlayerPrefs.SetString("playerName", playerName);
    }

    public void Load()
    {
        playerHP = PlayerPrefs.GetFloat("playerHp", 100);
        playerName = PlayerPrefs.GetString("playerName", "Bob");
    }

}
