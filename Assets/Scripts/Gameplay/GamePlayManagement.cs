using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManagement : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject InstructionPanel;
    [SerializeField] GameObject InstructionPanel2;
    [SerializeField] GameObject InstructionPanel3;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject pausebutton;
    [SerializeField] private GameObject scoretext;
    public static GamePlayManagement Instance { get; private set; }


    private void Awake()
    {
        startPanel.SetActive(true);
        pausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        InstructionPanel.SetActive(false);
        pausebutton.SetActive(false);
        scoretext.SetActive(false);

        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);

        }

        Instance = this;
    }
    void Start()
    {
        Time.timeScale = 0f;
    }


    void Update()
    {

    }
    public void StartGame()
    {

        Time.timeScale = 1.0f;
        startPanel.SetActive(false);
        pausebutton.SetActive(true);
        scoretext.SetActive(true);

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);

    }
    public void ResumeGame()
    {

        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
#if UNITY_WEBGL
        Debug.Log("Quit not supported in WebGL");
#else
    Application.Quit();
#endif
    }

    public void OpenInstructPanel() { 

        InstructionPanel.SetActive(true);
    }
    public void NextPanelP1(GameObject button)
    {
        InstructionPanel2.SetActive(true);
        ClosePanel(button);

    }
    public void NextPanelP2(GameObject button)
    {
        InstructionPanel3.SetActive(true);
        ClosePanel(button);

    }
    public void PrevPanelP2(GameObject button)
    {
        InstructionPanel.SetActive(true);
        ClosePanel(button);

    }
    public void PrevPanelP3(GameObject button)
    {
        InstructionPanel2.SetActive(true);
        ClosePanel(button);

    }
    public void ClosePanel(GameObject button)
    {
        button.transform.parent.gameObject.SetActive(false);
    }
    public void OpenSettingsPanel() { 

        SettingsPanel.SetActive(true);
    
    }
}
