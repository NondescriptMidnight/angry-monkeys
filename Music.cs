using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}

