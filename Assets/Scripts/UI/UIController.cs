using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    [Header("UI in Game")]
    public GameObject m_UIStartGame;
    public GameObject m_UIInGame;
    public GameObject m_UIEndGame;

    [Header("Button")] 
    public Button m_StartButton;
    public Button m_RestartButton;
    public Button m_QuitGameButton;

    [Header("Controller")] 
    public GameManager m_GameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        m_StartButton.onClick.AddListener(StartGame);
        m_RestartButton.onClick.AddListener(Restart);
        m_QuitGameButton.onClick.AddListener(QuitGame);
    }

    public void ShowUIStartGame()
    {
        m_UIStartGame.SetActive(true);
    }

    public void ShowUIInGame()
    {
        m_UIInGame.SetActive(true);
    }

    public void TurnOffUIInGame()
    {
        m_UIInGame.SetActive(false);
    }
    public void ShowUIEndGame()
    {
        m_UIEndGame.SetActive(true);
    }
    void StartGame()
    {
        // Tắt UI
        m_UIStartGame.SetActive(false);
        // Bắt đầu Game
        m_GameManager.StartGame();
    }

    void Restart()
    {
        // Tắt UI Engame
        m_UIEndGame.SetActive(false);
        // Restart game
        m_GameManager.RestartGame();
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
