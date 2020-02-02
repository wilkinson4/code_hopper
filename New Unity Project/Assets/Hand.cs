// Convert the 2D position of the mouse into a
// 3D position.  Display these on the game window.

using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    private Camera cam;
    public Sprite deadimage;
    public Sprite liveimage;
    public static bool _inputLocked;
    public float inputlockingTime = 0.5f;
    private int count;
    public Text scoreText;
    public XSpawn xspawn;

    void Start()
    {
        xspawn = new XSpawn();
        cam = Camera.main;
        count = xspawn.numFlies + xspawn.numBees + xspawn.numPeeds + xspawn.numTicks + xspawn.numSpiders;
        scoreText.text = $"Bugs Left: {count.ToString()}";
    }
    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        transform.position = point;
    }


    void UnlockInput()
    {
        _inputLocked = false;
        this.GetComponent<SpriteRenderer>().sprite = liveimage;
    }
    void LockInput()
    {
        _inputLocked = true;
        Invoke("UnlockInput", inputlockingTime);
    }
    public bool isInputLocked()
    {
        return _inputLocked;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isInputLocked())
            {
                Debug.LogWarning("Input locked");
            }
            else
            {
                LockInput();
                this.GetComponent<SpriteRenderer>().sprite = deadimage;
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.CompareTag("bug"))
                    {
                        count--;
                        scoreText.text = $"Bugs Left: {count.ToString()}";
                    }
                }
            }
        }
    }


}
