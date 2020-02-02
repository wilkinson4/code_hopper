using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossMoth: MonoBehaviour
{
    public float speed = 1.5f;
    public float rotateSpeed = 5.0f;
    public float rangex = 10f;
    public float rangey = 4.5f;
    public float timeheal = 0f;
    public float increase = 0f;
    private bool notDead = true;
    private bool locked = false;
    public int numhits = 20;
    public Sprite deadimage;
    public static bool TickOn = false;
    public ParticleSystem part;
    public AudioClip Splat;
    public ParticleSystem part2;
    public AudioClip Splat2;
    AudioSource audioSource;
    Vector3 newPosition;

    void Start()
    {
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(-rangex, rangex), Random.Range(-rangey, rangey));
    }

    void Update()
    {
        if (notDead)
        {
            if (Vector2.Distance(transform.position, newPosition) < 1)
                PositionChange();

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);

            LookAt2D(newPosition);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * .1f);
            SpinToEnd2D(newPosition);
        }
        timeheal += increase;
        increase = Random.Range(0f, .01f);
        if (timeheal >= 1f)
        {
            numhits++;
            timeheal = 0f;
        }
    }

    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;

        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
    }
    void SpinToEnd2D(Vector3 lookAtPosition)
    {

        transform.Rotate(Vector3.forward * -5);
    }
    private void OnMouseDown()
    {
        if (!locked && !Hand._inputLocked)
        {
            if (numhits > 0)
            {

                numhits--;
                AudioSource.PlayClipAtPoint(Splat, this.transform.position);
                Instantiate(part, this.transform.position, this.transform.rotation);
            }
            else
            {
                locked = true;
                this.GetComponent<SpriteRenderer>().sprite = deadimage;
                notDead = false;
                newPosition = new Vector2(transform.position.x, -30f);
                AudioSource.PlayClipAtPoint(Splat2, this.transform.position);
                Instantiate(part2, this.transform.position, this.transform.rotation);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
}
