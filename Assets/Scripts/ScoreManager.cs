using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score=0;
    public TextMeshProUGUI scoreText;

    [Header("Win Settings")]
    public int beginnerwinningScore = 6;
    public int interWinningScore = 8;
    public int advanceWinningScore = 10;

    public GameObject winUI;
    public GameObject goToMenuUI;
    private int currentTargetScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        score = 0;
        currentTargetScore = beginnerwinningScore;
    }
    public void SetToBeginner()
    {
        currentTargetScore = beginnerwinningScore;
        ResetScore();
    }
    public void SetToIntermediate()
    {
        currentTargetScore = interWinningScore;
        ResetScore();
    }
    public void SetToAdvance()
    {
        currentTargetScore = advanceWinningScore;
        ResetScore();
    }
    private void ResetScore()
    {
        score = 0;
        if (scoreText != null) scoreText.text = "0";
        if (winUI != null) winUI.SetActive(false);
        if (goToMenuUI != null) goToMenuUI.SetActive(false);
            
        Debug.Log("Level Set! Target: " + currentTargetScore);
    }

    public void AddPoint()
    {
        score++;
        Debug.Log(score);

        if (scoreText != null)
            scoreText.text = score.ToString();
        
        if (score >= currentTargetScore)
        {
            if (winUI != null) winUI.SetActive(true);
            if(goToMenuUI != null) goToMenuUI.SetActive(true);
            Debug.Log("WINNER!");
        }
    }

    public void ClearFallenPins()
    {
        PinScore[] pins = FindObjectsOfType<PinScore>();

        foreach (var pin in pins)
        {
            if (pin.counted)
            {
                Destroy(pin.gameObject);
            }
        }
    }

}
