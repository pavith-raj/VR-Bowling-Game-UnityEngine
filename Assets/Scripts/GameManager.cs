using UnityEngine;
using UnityEngine.SceneManagement;
using BNG;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject welcomeUI;
    public GameObject chooseLevelUI;
    public GameObject chooseColorUI;
    public GameObject tryAgainUI;

    [Header("Level References")]
    public GameObject beginnerLevel;
    public GameObject intermediateLevel;
    public GameObject advanceLevel;

    private static bool isExitToMenu = false;
    private static bool isBeginner = false;
    private static bool isIntermediate = false;
    private static bool isAdvance = false;

    private void Start()
    {
        //For Exit to Menu
        if (isExitToMenu)
        {
            welcomeUI.gameObject.SetActive(false);
            chooseLevelUI.gameObject.SetActive(true);
            isExitToMenu = false;
        }

        // -----Try again--------

        if (isBeginner)
        {
            welcomeUI.gameObject.SetActive(false);
            chooseLevelUI.gameObject.SetActive(false);

            chooseColorUI.gameObject.SetActive(true);
            beginnerLevel.gameObject.SetActive(true);

            ScoreManager.Instance.SetToBeginner();
            isBeginner = false;
        }
        else if (isIntermediate)
        {
            welcomeUI.gameObject.SetActive(false);
            chooseLevelUI.gameObject.SetActive(false);

            chooseColorUI.gameObject.SetActive(true);
            intermediateLevel.gameObject.SetActive(true);
            
            ScoreManager.Instance.SetToIntermediate();
            isIntermediate = false;
        }
        else if (isAdvance)
        {
            welcomeUI.gameObject.SetActive(false);
            chooseLevelUI.gameObject.SetActive(false);

            chooseColorUI.gameObject.SetActive(true);
            advanceLevel.gameObject.SetActive(true);

            ScoreManager.Instance.SetToAdvance();
            isAdvance = false;
        }
    }

    //void Update()
    //{
    //    if (InputBridge.Instance.LeftTriggerDown)
    //    {
    //        tryAgainUI.gameObject.SetActive(true);
    //    }
    //}

    public void TryAgain()
    {
        if (beginnerLevel.activeSelf)
        {
            BeginnerLevelReset();
        }
        else if (intermediateLevel.activeSelf)
        {
            IntermediateLevelReset();
        }
        else if (advanceLevel.activeSelf)
        {
            AdvanceLevelReset();
        }
    }
    public void ExitToMenu()
    {
        isExitToMenu = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ------Try Again----------------
    void BeginnerLevelReset()
    {
        isBeginner = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void IntermediateLevelReset()
    {
        isIntermediate = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void AdvanceLevelReset()
    {
        isAdvance = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //--------------------------------------

    public void ExitApplication()
    {
        Application.Quit();
    }
}
