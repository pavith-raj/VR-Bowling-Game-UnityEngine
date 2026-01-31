using UnityEngine;

public class LaneTriggerZone : MonoBehaviour
{
    public GameObject warningUI;
    public GameObject tryAgainUI;
    public GameObject goToMenuUI;

    [Header("Settings")]
    public int maxBalls = 3;
    public float deadBallSpeed = 0.1f;
    public float deadBallTime = 1f;  // Time required to decide ball is stuck
    public float uiDelay = 1f;  // Delay before showing Try Again

    private int ballsUsed = 0;
    private Rigidbody currentBall;
    private float stopTimer = 0f;
    private int scoreAtThrow = 0;

    private bool ballExited = false;
    private bool ballCounted = false;

    private void Start()
    {
        ballsUsed = 0;
        stopTimer = 0f;

        if (warningUI) warningUI.SetActive(false);
        if (tryAgainUI) tryAgainUI.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentBall = other.GetComponent<Rigidbody>();
            stopTimer = 0f;
            ballExited = false;
            ballCounted = false;
            scoreAtThrow = ScoreManager.Instance.score; // save score
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballExited = true;
            CountBallUsed();
        }
    }

    void Update()
    {
        if (currentBall == null) return;
        if (ballExited) return;

       
        if (ScoreManager.Instance.score > scoreAtThrow)
        {
            CountBallUsed();
            Destroy(currentBall.gameObject);
            return;
        }

        if (currentBall.linearVelocity.magnitude < deadBallSpeed)
        {
            stopTimer += Time.deltaTime;

            if (stopTimer >= deadBallTime)
            {
                Debug.Log("Dead Ball Detected");
                CountBallUsed();

                Destroy(currentBall.gameObject);
                currentBall = null;
            }
        }
        else
        {
            stopTimer = 0f;
        }
    }

    void CountBallUsed()
    {
        if (ballCounted) return;

        ballCounted = true;
        ballsUsed++;
        Debug.Log("Ball used: " + ballsUsed);
       
        if (ScoreManager.Instance.score == scoreAtThrow)
        {
            warningUI.SetActive(true);
            Invoke(nameof(DeactiveWarning), 1f);
        }
            
        if (ballsUsed >= maxBalls && !goToMenuUI.activeSelf)
        {
            Invoke(nameof(ShowTryAgain), uiDelay);
        }
    }

    void DeactiveWarning()
    {
        warningUI.SetActive(false);
    }

    void ShowTryAgain()
    {
        if (!goToMenuUI.activeSelf)
        {
            tryAgainUI.SetActive(true);
        }
     
    }
}