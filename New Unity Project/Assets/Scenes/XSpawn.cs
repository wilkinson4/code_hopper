using System.Collections;
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
    public GameObject MothBoss;

    public int numFlies = 20;
    public int numTicks = 20;
    public int numSpiders = 20;
    public int numPeeds = 20;
    public int numBees = 20;

    public static int killFlies = 0;
    public static int killTicks = 0;
    public static int killSpiders = 0;
    public static int killPeeds = 0;
    public static int killBees = 0;

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
    private bool doneFly = true, doneTick = false, doneSpider = false, donePeed = false, doneBee = false;

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
                yield return new WaitForSeconds(10f);
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
                yield return new WaitForSeconds(6f);
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
                yield return new WaitForSeconds(2f);
            }
        while (killFlies < numFlies && killTicks < numTicks && killPeeds < numPeeds && killSpiders < numSpiders && killBees < numBees)
        {
            Debug.Log("Total Left kill: " + killBees + "Bees " + killFlies + "Flies " + killPeeds + "Peeds " + killSpiders + "Spiders " + killTicks + "Ticks");
            Debug.Log("Total Left current: " + currentBeecount + "Bees " + currentflycount + "Flies " + currentPeedcount + "Peeds " + currentSpidercount + "Spiders " + currentTickcount + "Ticks");
            Debug.Log("Waiting on moth");
            yield return new WaitForSeconds(5f);
        }
        SpawnPrefebMothBoss();


    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = transform.position.x;
        //get the Input from Vertical axis
        float verticalInput = transform.position.y;

        //update the position
        Debug.Log("Flies: " + currentflycount + "CFly " + iFly + "iFly " + numFlies + "nFly " + doneFly);
        if (currentflycount < 1 && iFly < numFlies && doneFly) { Debug.Log("OverrideFly: " + currentflycount + "CFly " + iFly + "iFly " + numFlies + "nFly " + doneFly); SpawnPrefebFly(); }
        if (currentPeedcount < 1 && iPeed < numPeeds && donePeed) { Debug.Log("OverridePeed" + currentPeedcount + "CFly " + iPeed + "iFly " + numPeeds + "nFly " + donePeed); SpawnPrefebPeed(); }
        if (currentTickcount < 1 && iTick < numTicks && doneTick) { Debug.Log("OverrideTick"); SpawnPrefebTick(); }
        if (currentSpidercount < 1 && iSpider < numSpiders && doneSpider ) { Debug.Log("OverrideSpider"); SpawnPrefebSpider(); }
        if (currentBeecount < 1 && iBee < numBees && doneBee) { Debug.Log("OverrideBee"); SpawnPrefebBees(); }
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
            doneFly = true;
            Instantiate(Flys, transform.position, Quaternion.identity);
        }
    }
    void SpawnPrefebTick()
    {


        if (iTick < numTicks)
        {
            currentTickcount++;
            iTick++;
            doneTick = true; donePeed = false;
            Instantiate(Ticks, transform.position, Quaternion.identity);
        }
    }

    void SpawnPrefebSpider()
    {
        if (iSpider < numSpiders)
        {
            currentSpidercount++;
            iSpider++;
            doneSpider = true; doneTick = false; 
            Instantiate(Spiders, transform.position, Quaternion.identity);
        }
    }
   void SpawnPrefebPeed()
    {

        if (iPeed < numPeeds)
        {
            currentPeedcount++;
            iPeed++;
            donePeed = true; doneFly = false;
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
            doneBee = true; doneSpider = false;
            currentBeecount++;
            iBee++;
            Instantiate(Bees, transform.position, Quaternion.identity);
        }

    }
    void SpawnPrefebMothBoss()
    {
        doneBee = false;
            Instantiate(MothBoss, transform.position, Quaternion.identity);
        
    }
}
