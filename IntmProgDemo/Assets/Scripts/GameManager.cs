using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField]
    TextMeshProUGUI scoreTMP;

    [SerializeField]
    private CubePlayer player;

    [SerializeField]
    LayerMask rayLayerMask_Floor;

    [Header("Prefabs")]
    [SerializeField] //shows in inspector without being public 
    private GameObject coinPre;

    [SerializeField] 
    private int startCoins = 1000;

    private float timer = 0;
    private float timerTotal = 1;

    [HideInInspector]
    public int score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < startCoins; i++)
        {
            SpawnCoin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timerTotal)
        {
            timer = 0;
            SpawnCoin();
        }
        else
        {
            timer += Time.deltaTime;
        }

        //left mouse button
        if (Input.GetMouseButtonUp(0))
        {
            //make raycast to ground
            Vector2 clickPos = Input.mousePosition;
            Ray currentRay = Camera.main.ScreenPointToRay(clickPos);
            RaycastHit hit;

            if (Physics.Raycast(currentRay, out hit, 3000, rayLayerMask_Floor))
            {
                //TODO: Player move to position
                print("hit detected: " + hit.point);

                player.MoveTo(hit.point);
            }
        }

        scoreTMP.text = "<color=#000fff>Score: </color>" + score;
    }

    //spawn a coin at a random place
    void SpawnCoin()
    {
        GameObject coin = Instantiate(coinPre);
        Vector3 v3 = new Vector3(Random.Range(-10f, 10f), Random.Range(5f, 10f), Random.Range(-10f, 10f));
        coin.transform.position = v3;
    }

}
