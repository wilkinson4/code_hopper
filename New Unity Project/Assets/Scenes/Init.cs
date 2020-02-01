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
    private float moveSpeed = 1f;
    private float MaxX = 10f;
    public bool swap = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFly());
    }

    private IEnumerator SpawnFly()
    {
        for (int i = 0; i < numFlies; i++)
        {
            SpawnPrefebFly();
            yield return new WaitForSeconds(3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        if (swap)
        {
            if (transform.position.x > MaxX)
            {
                swap = false;
                transform.position = transform.position + new Vector3(horizontalInput + moveSpeed, verticalInput * -1, 0);
            }
            else
            {
                transform.position = transform.position + new Vector3(horizontalInput + moveSpeed, verticalInput, 0);
            }
 
        }
        else
        {
            if (transform.position.x < -MaxX)
            {
                swap = true;
                transform.position = transform.position + new Vector3(horizontalInput - moveSpeed, verticalInput * -1, 0);
            }
            else
            {
                transform.position = transform.position + new Vector3(horizontalInput - moveSpeed, verticalInput, 0);
            }
            
        }
        

        //output to log the position change
        Debug.Log(transform.position);
    }
    void SpawnPrefebFly()
    {
        Instantiate(Fly, transform.position, Quaternion.identity); ;
    }
}
