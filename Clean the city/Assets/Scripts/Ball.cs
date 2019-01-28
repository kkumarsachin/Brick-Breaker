
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] paddle paddle1;
    [SerializeField] float xpush = 2f;
    [SerializeField] float ypush = 15f;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float randomFactor = 0.2f;
    Vector2 paddletovector;
    bool hasStarted = false;
    AudioSource myAudiosource;
    Rigidbody2D myrigidbody2d;
    void Start()
    {
        paddletovector = transform.position - paddle1.transform.position;
        myAudiosource = GetComponent<AudioSource>();
        myrigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            Lockballtopaddle();
            LaunchBallOnmouseclick();
        }
    }

    private void LaunchBallOnmouseclick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myrigidbody2d.velocity = new Vector2(xpush, ypush);
        }
    }

    private void Lockballtopaddle()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlepos + paddletovector;
    }  

    private void OnCollisionEnter2D(Collision2D collision)

    {
        Vector2 velocitytweak = new Vector2(Random.Range(0f,randomFactor), Random.Range(0f, randomFactor));
;        if (hasStarted)
        {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            myAudiosource.PlayOneShot(clip);
            myrigidbody2d.velocity += velocitytweak;
        }
    }
}
