using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public enum xPositions { left, right }
public enum yPositions { top, middle, bottom }

public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Camera cameraMain;

    VendScript vendor;

    Vector3 spawnPos;
    public GameObject myObject;

    public xPositions xPosition;
    public yPositions yPosition;
    float zPos = 0;

    bool vendAllowed = true;

    void Start()
    {      
        vendor = GameObject.Find("BigVendor").GetComponent<VendScript>();

        float xPos = parseXEnum(xPosition);
        float yPos = parseYEnum(yPosition);

        spawnPos = new Vector3(xPos, yPos, zPos);

        makeObject();
    }

    public void Vend()
    {
        if (vendAllowed)
        {
            vendAllowed = false;
            myObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 10, ForceMode.Impulse);

            StartCoroutine(WaitAndVend(3));
        }
    }

    void makeObject()
    {
        int toVend = Random.Range(0, vendor.items.Count);
        myObject = Instantiate(vendor.items[toVend], spawnPos, Quaternion.identity);
        vendAllowed = true;
    }

    IEnumerator WaitAndVend(int sec)
    {
        yield return new WaitForSeconds(sec);
        makeObject();
        vendAllowed= true;
    }

    float parseXEnum(xPositions x)
    {
        switch (x)
        {
            case xPositions.left:
                return -.5f;
            case xPositions.right:
                return 2.75f;
        }

        return 0;
    }

    float parseYEnum(yPositions y)
    {
        switch (y)
        {
            case yPositions.top:
                return 8.5f;
            case yPositions.middle:
                return 5.5f;
            case yPositions.bottom:
                return 2f;
        }

        return 0;
    }
}
