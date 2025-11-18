using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private static ScoreUI instance;

    public static ScoreUI Instance { get { return instance; } }

    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
        scoreText=GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }


}
