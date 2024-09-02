using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _startButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _startButton.onClick.AddListener(StartButton);
    }

    #endregion

    #region Private methods

    private void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}