using UnityEngine;

public class Resetter : MonoBehaviour
{

    public Rigidbody2D projectile;
    public float resetSpeed = 0.025f;
    private int amountOfObjects;


    private SpringJoint2D spring;


    // Use this for initialization
    void Start()
    {
        spring = projectile.GetComponent<SpringJoint2D>();

    }

    // Update is called once per frame
    void Update()
    {
        amountOfObjects = GameObject.FindGameObjectsWithTag("smashable").Length;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        if (spring == null && projectile.velocity.sqrMagnitude < resetSpeed)
        {
            Reset();
        }
    }

    void OnTriggerExit2D(Collider2D boundaryBox)
    {
        if (boundaryBox.GetComponent<Rigidbody2D>() == projectile)
        {
            Reset();
        }
    }

    void Reset()
    {
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
