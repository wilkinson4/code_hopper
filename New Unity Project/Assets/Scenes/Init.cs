using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public Transform[] teleport;
    public GameObject Fly;
    public GameObject Tick;
    public GameObject Peed;
    public GameObject Spider;
    public GameObject Bee;
    public int numFlies = 20;
    public int numTicks = 20;
    public int numPeeds = 20;
    public int numSpiders = 20;
    public int numBees = 20;
    private float moveSpeed = 0.3f;
    private float Ychange = 1f;
    private float MaxX = 10f;
    public bool swap = true;
    public static int currentflycount = 0;
    public static int currentTickcount = 0;
    public static int currentPeedcount = 0;
    public static int currentSpidercount = 0;
    public static int currentBeecount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFly());
    }

    private IEnumerator SpawnFly()
    {
        for (int i = 0; i < numFlies; i++) { 
            SpawnPrefebFly();
            yield return new WaitForSeconds(3f);
        }
        for (int i = 0; i < numTicks; i++)
        {
            SpawnPrefebTick();
            yield return new WaitForSeconds(3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = transform.position.x;
        //get the Input from Vertical axis
        float verticalInput = transform.position.y;

        //update the position
        if (currentflycount < 1) { Debug.Log("Spawn NOW"); 
            SpawnPrefebFly(); }
        if (swap)
        {
            if (transform.position.x > MaxX)
            {
                swap = false;
                Ychange = -1f;
            }
            transform.position = new Vector3(horizontalInput + moveSpeed, verticalInput * Ychange, 0);
 
        }
        else
        {
            if (transform.position.x < -MaxX)
            {
                swap = true;
                Ychange = 1f;
            }
            transform.position = new Vector3(horizontalInput - moveSpeed, verticalInput * Ychange, 0);
     
        }


        //output to log the position change
        Debug.Log(currentflycount);
    }
    void SpawnPrefebFly()
    {
        currentflycount++;
        numFlies--;
        Instantiate(Fly, transform.position, Quaternion.identity); ;
    }
    void SpawnPrefebTick()
    {
        currentTickcount++;
        numTicks--;
        Instantiate(Tick, transform.position, Quaternion.identity); ;
    }
    void SpawnPrefebPeeds()
    {
        currentPeedcount++;
        numPeeds--;
        Instantiate(Peed, transform.position, Quaternion.identity); ;
    }
    void SpawnPrefebSpider()
    {
        currentSpidercount++;
        numSpiders--;
        Instantiate(Spider, transform.position, Quaternion.identity); ;
    }
    void SpawnPrefebBees()
    {
        currentBeecount++;
        numBees--;
        Instantiate(Bee, transform.position, Quaternion.identity); ;
    }

}
