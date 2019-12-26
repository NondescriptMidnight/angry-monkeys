using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonManager : MonoBehaviour
{ 

    // Use this for initialization
    public void Repeat()
    {
        Application.LoadLevel(0);
    }
    public void Continue()
    {
        Application.Quit();
    }
}
