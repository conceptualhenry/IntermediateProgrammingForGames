using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public Camera cam;

    LayerMask Pressable;

    public int itemsTotal;

    [SerializeField]
    GameObject buttonMachine;
    Transform[] buttons;

    [Header("Vendable items")]
    [SerializeField]
    public List<GameObject> items = new List<GameObject>();

    List<GameObject> itemsCurrent;

    [Header("Positions")]
    public List<float> xPositions;
    public List<float> yPositions;
    public float zPosition;

    int vendedItems;

    [SerializeField] TextMeshPro bigVendorDisplay;


    void Start()
    {
        var n = 0;
        for (int i = 0; i < xPositions.Count; i++)
        {
            for (int j = 0; j < yPositions.Count; j++)
            {
                Instantiate(items[n], new Vector3(xPositions[i], yPositions[j], zPosition), Quaternion.identity, this.transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            LayerMask mask = LayerMask.GetMask("Pressable");

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Button button = hit.collider.GetComponent<Button>();

                button.Vend();

                vendedItems++;
            }    
        }

        bigVendorDisplay.text = (vendedItems > 20) ? "BIG VENDOR!!!" : "";
    }

}
