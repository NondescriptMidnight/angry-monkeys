using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int score = 0;


    void Start()
    {
        UpdateScore();
    }

    public void HandlePoints(int points)
    {
        score += points;
    }
    public static void UpdateScore()
    {
        score = 0;
    }
}
