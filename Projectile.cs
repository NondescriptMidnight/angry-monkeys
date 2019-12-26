using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioClip pullBack;
    public AudioClip monkeyLaugh;
    public AudioClip releaseSling;
    public AudioClip monkeyScream;

    public SpriteRenderer monkeyHead;

    public float minStretchX,maxStretchX;
    public float minStretchY,maxStretchY;
    private float maxStretcchSqu;
    private float circleRadius;

    public float moveSpeed = 10f;

    private Vector2 prevVelocity;
    private Vector2 touchPos;

    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;
    private Vector3 slingShotMiddleVector;
    private Vector3 monkeyPos;
    private Vector3 startMonkeyPos;

    private SpringJoint2D spring;
    private Ray rayToMouse;
    private Ray leftCatapultToProjectile;

    private bool clickedOn;
    private bool soundPlayed = false;
    private bool releaseSoundPlayed = false;

    private Transform catapult;

    public AudioClip[] hitSounds;
    public float smashSoundDelay = 0.25f;
    private float smashSoundTiming;
    public static int shotCounter = 30;
    public float countDownTextx = 5;
    public float countDownTexty = 5;

    private bool checkForRedirect = false;
    private bool shotCounted = false;

    void Awake()
    {
        startMonkeyPos = transform.position;
        spring = GetComponent<SpringJoint2D>();
        catapult = spring.connectedBody.transform;

    }

    void Start()
    {

        LineRendererSetup();
        rayToMouse = new Ray(catapult.position, Vector3.zero);
        leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
        CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
        circleRadius = circle.radius;

    }
    void LineRendererSetup()
    {
        catapultLineBack.sortingLayerName = "Foreground";
        catapultLineFront.sortingLayerName = "Foreground";

        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;

    }


    void Update()
    {
        BallTracker();
        if (Input.GetMouseButtonDown(0) && spring != null)
        {
            spring.enabled = false;
            clickedOn = true;
        }
        if (Input.GetMouseButtonUp(0) && spring !=null)
        {
            spring.enabled = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
            clickedOn = false;
            Debug.Log("isfired");
        }
        if (clickedOn)

            Dragging();

        if (spring != null)
        {
            

            if (GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                Destroy(spring);
                GetComponent<Rigidbody2D>().velocity = prevVelocity;


            }
            if (!clickedOn)

                prevVelocity = GetComponent<Rigidbody2D>().velocity;
            LineRendererUpdate();


        }
        else
        {
            if (!releaseSoundPlayed)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(monkeyScream);
                audio.PlayOneShot(releaseSling);
                releaseSoundPlayed = true;
            }
            if (!shotCounted)
            {
                shotCounter--;
                shotCounted = true;
            }
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;


        }
    }

    void Dragging()
    {
        shotCounted = false;
        monkeyPos = gameObject.transform.position;
        float axisVertical = Input.GetAxisRaw("Mouse Y") * moveSpeed * Time.deltaTime;
        float axisHorizontal = Input.GetAxisRaw("Mouse X") * moveSpeed * Time.deltaTime;
        monkeyPos.x = Mathf.Clamp(monkeyPos.x + axisHorizontal, startMonkeyPos.x - minStretchX, startMonkeyPos.x + maxStretchX);
        monkeyPos.y = Mathf.Clamp(monkeyPos.y + axisVertical, startMonkeyPos.y - minStretchY, startMonkeyPos.y + maxStretchY);
        transform.position = monkeyPos;


        if (!soundPlayed)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(monkeyLaugh);
            audio.PlayOneShot(pullBack);
            soundPlayed = true;
        }

    }


    void LineRendererUpdate()
    {
        Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);
    }

    public void BallTracker()
    {
        if (shotCounter <= -1 && !checkForRedirect)
        {
            EndGame();
        }
    }
    void OnGUI()
    {
        GUIStyle countDown = new GUIStyle(GUI.skin.GetStyle("label"));
        countDown.fontSize = 44;
        countDown.normal.textColor = Color.white;

        GUI.Label(new Rect(countDownTextx, countDownTexty, 500, 100), "BALLS LEFT: " + shotCounter, countDown);

    }


    void OnCollisionEnter2D(Collision2D hit)
        {
        AudioSource audio = GetComponent<AudioSource>();
        AudioClip hitVariation = hitSounds[Random.Range(0, hitSounds.Length)];
        if (smashSoundTiming <= 0)
            audio.PlayOneShot(hitVariation);
            smashSoundTiming = smashSoundDelay;
        }

    void EndGame()
    {
      shotCounter = 30;
    //window.location = "endgame.php"
    Application.LoadLevel(1);
    Debug.Log("redirected!");
    checkForRedirect = true;
    }
        }


