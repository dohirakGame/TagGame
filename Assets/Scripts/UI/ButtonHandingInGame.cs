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
		AudioManager.instance.Play("Click");

		if (playerData.levelComplete < levelController.levelIndex && levelComplete) playerData.SetData(levelController.levelIndex);

        SceneManager.LoadScene(0);
    }

    public void StartAgain()
    {
		AudioManager.instance.Play("Click");

		SceneManager.LoadScene(levelController.levelIndex);
    }
    
    public void SetPause()
    {
		AudioManager.instance.Play("Click");

		timer.GetComponent<TimerTracker>().StopTimer();
        
		pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        game.SetActive(false);
        level.SetActive(false);
        timer.SetActive(false);
    }

    public void ContinueGame()
    {
		AudioManager.instance.Play("Click");

		pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        game.SetActive(true);
        level.SetActive(true);
        timer.SetActive(true);

        timer.GetComponent<TimerTracker>().StartTimer();
    }

    public void GameLaunch()
    {
		AudioManager.instance.Play("Click");

		launchPanel.SetActive(false);
        game.SetActive(true);
        level.SetActive(true);
        pauseButton.SetActive(true);
        timer.SetActive(true);

        timer.GetComponent<TimerTracker>().StartTimer();
    }

    public void GameOver()
    {
		AudioManager.instance.Play("Firework1");

		victoryPanel.SetActive(true);
        game.SetActive(false);
        level.SetActive(false);
        pauseButton.SetActive(false);
        timer.SetActive(false);

    }
}
