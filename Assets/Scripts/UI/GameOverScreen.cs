using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.OnDied += ShowScreenGameOver;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.OnDied -= ShowScreenGameOver;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void ShowScreenGameOver()
    {
        const float timeOnChange = 2;
        StartCoroutine(ChangeSmothScreen(timeOnChange));

        Time.timeScale = 0;
    }

    private IEnumerator ChangeSmothScreen(float timeOnChange)
    {
        float currentTime = 0f;
        do
        {
            _gameOverGroup.alpha = Mathf.Lerp(_gameOverGroup.alpha, 1, currentTime / timeOnChange);
            currentTime += Time.deltaTime;

            yield return null;
        } while (currentTime <= timeOnChange);
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
