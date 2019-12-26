using UnityEngine;
using System.Collections;

public class ScoreTrackering : MonoBehaviour
{
    public static int scoreNum = 0;

    void OnGUI()
    {
        GUIStyle scorer = new GUIStyle(GUI.skin.GetStyle("label"));
        scorer.fontStyle = FontStyle.Bold;
        scorer.fontSize = 44;
        scorer.normal.textColor = Color.black;

        GUI.Label(new Rect(5, 5, 500, 100), "SCORE:  " + scoreNum, scorer);

    }
}