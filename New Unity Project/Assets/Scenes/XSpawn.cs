﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XSpawn : MonoBehaviour
{ 
    public Transform[] teleport;
    public GameObject Flys;
    public GameObject Ticks;
    public GameObject Spiders;
    public GameObject Bees;
    public GameObject Peeds;
    public int numFlies = 10;
    public int numTicks = 10;
    public int numSpiders = 10;
    public int numPeeds = 10;
    public int numBees = 10;
    private float moveSpeedX = 1f;
    private float moveSpeedY = 0.5f;
    private Vector2 defaultXSpawn = new Vector2(0f, 5f);
    private Vector2 defaultYSpawn = new Vector2(10f, 0f);
    private float Ychange = 1f;
    private float MaxX = 10f;
    private float MaxY = 5f;
    public bool swap = true;
    public bool xory = true;
    public static int currentflycount = 0;
    public static int currentTickcount = 0;
    public static int currentSpidercount = 0;
    public static int currentPeedcount = 0;
    public static int currentBeecount = 0;
    public int iFly, iTick, iSpider, iPeed, iBee;
    private bool doneFly = false, doneTick = true, doneSpider = true, donePeed = true, doneBee = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFly());
    }

    private IEnumerator SpawnFly()
    {
        int i = 0;
        for (iFly = 0; iFly < numFlies; i++)
            {
                SpawnPrefebFly();
                yield return new WaitForSeconds(3f);
            }
        defaultXY();
        for (iPeed = 0; iPeed < numPeeds; i++)
            {
                SpawnPrefebPeed();
                yield return new WaitForSeconds(3f);
            }
        defaultXY();
        for (iTick = 0; iTick < numTicks; i++)
            {
                SpawnPrefebTick();
                yield return new WaitForSeconds(4f);
            }
        for (iSpider = 0; iSpider < numSpiders; i++)
            {
                SpawnPrefebSpider();
                yield return new WaitForSeconds(0.8f);
            }
        defaultXY();
        for (iBee = 0; iBee < numBees; i++)
            {
                SpawnPrefebBees();
                yield return new WaitForSeconds(0.8f);
            }



    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(currentflycount + "Fly " + currentPeedcount + "Peed " + currentTickcount + "Tick " + currentSpidercount + "Spider " + currentBeecount + "Bee");
        //get the Input from Horizontal axis
        float horizontalInput = transform.position.x;
        //get the Input from Vertical axis
        float verticalInput = transform.position.y;

        //update the position
        if (currentflycount < 1 && iFly < numFlies && !doneFly) { Debug.Log("OverrideFly"); SpawnPrefebFly(); }
        if (currentPeedcount < 1 && iPeed < numPeeds && !donePeed) { Debug.Log("OverridePeed"); SpawnPrefebPeed(); }
        if (currentTickcount < 1 && iTick < numTicks && !doneTick) { Debug.Log("OverrideTick"); SpawnPrefebTick(); }
        if (currentSpidercount < 1 && iSpider < numSpiders && !doneSpider ) { Debug.Log("OverrideSpider"); SpawnPrefebSpider(); }
        if (currentBeecount < 1 && iBee < numBees && !doneBee) { Debug.Log("OverrideBee"); SpawnPrefebBees(); }
        if (xory)
        {
            if (swap)
            {
                if (transform.position.x > MaxX)
                {
                    swap = false;
                    Ychange = -1f;
                }
                transform.position = new Vector3(horizontalInput + moveSpeedX, verticalInput * Ychange, 0);

            }
            else
            {
                if (transform.position.x < -MaxX)
                {
                    swap = true;
                    Ychange = 1f;
                }
                transform.position = new Vector3(horizontalInput - moveSpeedX, verticalInput * Ychange, 0);

            }
        }
        else
        {
            if (swap)
            {
                if (transform.position.y > MaxY)
                {
                    swap = false;
                    Ychange = -1f;
                }
                transform.position = new Vector3(horizontalInput * Ychange, verticalInput + moveSpeedY, 0);

            }
            else
            {
                if (transform.position.y < -MaxY)
                {
                    swap = true;
                    Ychange = 1f;
                }
                transform.position = new Vector3(horizontalInput * Ychange, verticalInput - moveSpeedY, 0);

            }
        }


            //output to log the position change
    }
    void defaultXY()
    {
        xory = !xory;
        if (xory)
        {
            transform.position = defaultXSpawn;
        }
        else
        {
            transform.position = defaultYSpawn;
        }
    }
    void SpawnPrefebFly()
    {

        if (iFly < numFlies)
        {
            currentflycount++;
            iFly++;
            if (iFly >= numFlies) { doneFly = true; donePeed = false; }
            Instantiate(Flys, transform.position, Quaternion.identity);
        }
    }
    void SpawnPrefebTick()
    {


        if (iTick < numTicks)
        {
            currentTickcount++;
            iTick++;
            if (iTick >= numTicks) { doneTick = false; doneSpider = true; }
            Instantiate(Ticks, transform.position, Quaternion.identity);
        }
    }

    void SpawnPrefebSpider()
    {
        if (iSpider < numSpiders)
        {
            currentSpidercount++;
            iSpider++;
            if (iSpider >= numSpiders) { doneSpider = false; doneBee = true; }
            Instantiate(Spiders, transform.position, Quaternion.identity);
        }
    }
   void SpawnPrefebPeed()
    {

        if (iPeed < numPeeds)
        {
            currentPeedcount++;
            iPeed++;
            if (iPeed >= numPeeds ) { donePeed = false; doneTick = true; }
            if (transform.position.y > 4)
            {
                transform.position = new Vector2(10f, 4f);
            }
            else if (transform.position.y < -4)
            {
                transform.position = new Vector2(10f, -4f); 
            }
            Instantiate(Peeds, transform.position, Quaternion.identity);
             
        }
    }
    void SpawnPrefebBees()
    {
        if (iBee < numBees)
        {
            currentBeecount++;
            iBee++;
            Instantiate(Bees, transform.position, Quaternion.identity);
        }

    }
}
