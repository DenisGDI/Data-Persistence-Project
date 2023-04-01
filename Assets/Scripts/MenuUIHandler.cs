using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private InputField playerName;
    [SerializeField] private Text bestScore;
    public void Awake()
    {
        DataManager.Instance.LoadBestScore();
        bestScore.text = $"Best Score: {DataManager.Instance.BestPlayer}: {DataManager.Instance.BestScore}";
    }
    public void StartGame()
    {
        DataManager.Instance.PlayerName = playerName.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
