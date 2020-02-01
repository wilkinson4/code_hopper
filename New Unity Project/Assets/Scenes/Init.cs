using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public Transform[] teleport;
    public GameObject Fly;
    public GameObject[] Bee;
    public GameObject[] Roach;
    public int numFlies = 20;
    public int numBees = 20;
    public int numRoaches = 20;
    private float moveSpeed = 0.3f;
    private float Ychange = 1f;
    private float MaxX = 10f;
    public bool swap = true;
    public static int currentflycount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFly());
    }

    private IEnumerator SpawnFly()
    {
        for (int i = 0; i < numFlies; i++)
        {
            currentflycount++;
            SpawnPrefebFly();
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
        if (currentflycount < 1) { SpawnFly(); }
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
        Instantiate(Fly, transform.position, Quaternion.identity); ;
    }

}
