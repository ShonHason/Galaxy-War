using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText; 
    int score = 0;

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();    
    }
}
