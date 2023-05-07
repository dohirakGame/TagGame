using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandingInGame : MonoBehaviour
{
    [Header("Необходимые компоненты")]
    [SerializeField] private LevelController levelController;
    [SerializeField] private PlayerData playerData;
    
    [Header("Панели для меню")]
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject launchPanel;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    
    [Header("Игровое поле")]
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject timer;
    private void Start()
    {
        game.SetActive(false);
        victoryPanel.SetActive(false);
        level.SetActive(false);
        pauseMenu.SetActive(false);
        launchPanel.SetActive(true);
        timer.SetActive(false);
    }

	public void ExitToMenu(bool levelComplete)
    {
        if (playerData.levelComplete < levelController.levelIndex && levelComplete) playerData.SetData(levelController.levelIndex);
        SceneManager.LoadScene(0);
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(levelController.levelIndex);
    }
    
    public void SetPause()
    {
		timer.GetComponent<TimerTracker>().StopTimer();
        
		pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        game.SetActive(false);
        level.SetActive(false);
        timer.SetActive(false);
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        game.SetActive(true);
        level.SetActive(true);
        timer.SetActive(true);

        timer.GetComponent<TimerTracker>().StartTimer();
    }

    public void GameLaunch()
    {
        launchPanel.SetActive(false);
        game.SetActive(true);
        level.SetActive(true);
        pauseButton.SetActive(true);
        timer.SetActive(true);

        timer.GetComponent<TimerTracker>().StartTimer();
    }

    public void GameOver()
    {
        victoryPanel.SetActive(true);
        game.SetActive(false);
        level.SetActive(false);
        pauseButton.SetActive(false);
        timer.SetActive(false);

    }
}
