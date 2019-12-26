using UnityEngine;

public class SmashController : MonoBehaviour
{

    public AudioClip smash;
    public AudioClip pop;
    private Projectile projectile;

    public int scoreValue = 1;
    public GameObject popInstance;

    private float timer;

    private ScoreTrackering scoreKeeper;

    private float soundReplay = 0f;
    private bool playSound = false;

    void Start()
    {

        timer = 0.5f;
        soundReplay = smash.length;
    }
    void Update()
    {
        soundReplay -= Time.deltaTime;
        if(soundReplay >= 0)
        {
            soundReplay = smash.length;
            playSound = true;
        }
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource audio = GetComponent<AudioSource>();
        Projectile monkey = col.gameObject.GetComponent<Projectile>();
        if (monkey)
        {
            ScoreTrackering.scoreNum += 1;
            GameObject playPopping = popInstance;
            GameObject makePop = Instantiate(playPopping, transform.position, Quaternion.identity) as GameObject;
            if (playSound)
            {
                audio.PlayOneShot(smash);
                audio.PlayOneShot(pop);
                playSound = false;
            }
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(makePop, 0.3f);
            Destroy(gameObject, smash.length);
        }
    }
}

