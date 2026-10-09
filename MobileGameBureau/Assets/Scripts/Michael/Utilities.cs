using UnityEngine;
using UnityEngine.UI;

public class Utilities : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject gameMenuScreen;

    [Header("Sub UI")]
    [SerializeField] private GameObject settingsTab;

    [Header("Buttons")]
    [SerializeField] private Button openGameButton;
    [SerializeField] private Button closeGameButton;
    [SerializeField] private Button settingsButton;

    [SerializeField] private Button returnSettingsButton;

    private void Awake()
    {
        startScreen.SetActive(true);

        openGameButton.onClick.AddListener(() =>
        { 
            startScreen.SetActive(false);
            gameMenuScreen.SetActive(true);
        });

        closeGameButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        settingsButton.onClick.AddListener(() => {
            gameMenuScreen.SetActive(false);
            settingsTab.SetActive(true);
        });

        returnSettingsButton.onClick.AddListener(() => {
            settingsTab.SetActive(false);
            gameMenuScreen.SetActive(true);
        });

    }

}
