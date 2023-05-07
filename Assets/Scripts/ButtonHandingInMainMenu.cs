using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandingInMainMenu : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject selectLevel;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject resetButtons;
    [SerializeField] private GameObject resetData;

    [SerializeField] private GameObject[] levels;

    private void Start()
    {
        ToBack();
    }

    private GameObject[] SetLevels()
    {
        return GameObject.FindGameObjectsWithTag("Levels");
    }

    private void SetInteractableLevels(GameObject[] levels)
    {
        for (int i = playerData.levelComplete+1; i < levels.Length; i++)
        {
            levels[i].GetComponent<Button>().interactable = false;
        }
    }

    public void ShowLevels()
    {
        mainMenu.SetActive(false);
        settingsButton.SetActive(false);
        backButton.SetActive(true);
        selectLevel.SetActive(true);
        
        levels = SetLevels();
        SetInteractableLevels(levels);
    }

    public void ShowSettings()
    {
        mainMenu.SetActive(false);
        settingsButton.SetActive(false);
        backButton.SetActive(true);
        resetData.SetActive(true);
    }

    public void ToBack()
    {
        mainMenu.SetActive(true);
        settingsButton.SetActive(true);
        backButton.SetActive(false);
        selectLevel.SetActive(false);
        resetData.SetActive(false);
    }
    
    public void SelectLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ShowResetButtons()
    {
        resetButtons.SetActive(true);
    }
    public void HideResetButtons()
    {
        resetButtons.SetActive(false);
    }
    public void ResetData()
    {
        playerData.ResetData();
    }
}
