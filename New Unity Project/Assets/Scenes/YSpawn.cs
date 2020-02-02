using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSpawn : MonoBehaviour
{
    public Transform[] teleport;
    public static GameObject Peeds;
    public static GameObject Bees;
    public GameObject thisPeed;
    public GameObject thisBee;
    private float moveSpeed = 0.1f;
    private float Xchange = 1f;
    private float MaxY = 5f;
    public bool swap = true;
    private int iBee, iPeed;
    public static Vector3 MyPos;

    // Start is called before the first frame update
    void Start()
    {
        Peeds = thisPeed;
        Bees = thisBee;
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = transform.position.x;
        //get the Input from Vertical axis
        float verticalInput = transform.position.y;

        //update the position


        if (swap)
        {
            if (transform.position.y > MaxY)
            {
                swap = false;
                Xchange = -1f;
            }
            MyPos = new Vector3(horizontalInput * Xchange, verticalInput + moveSpeed, 0);
            transform.position = MyPos;
        }
        else
        {
            if (transform.position.y < -MaxY)
            {
                swap = true;
                Xchange = 1f;
            }
            MyPos = new Vector3(horizontalInput * Xchange, verticalInput - moveSpeed, 0);
            transform.position = MyPos;

        }
    }

        //output to log the position change




}
