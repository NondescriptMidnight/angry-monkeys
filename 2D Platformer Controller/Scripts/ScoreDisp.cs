using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisp : MonoBehaviour {

    public float screLft;
    public float screDwn;

    void OnGUI()
    {
        GUIStyle scorer = new GUIStyle(GUI.skin.GetStyle("label"));
        scorer.fontSize = 50;
        scorer.normal.textColor = Color.red;

        GUI.Label(new Rect(screLft, screDwn, 500, 100), "SCORE:  " + ScoreTrackering.scoreNum, scorer);

    }
}


