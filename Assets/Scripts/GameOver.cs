using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text _resultLabel;
    [SerializeField] private Button _menuButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _resultLabel.text = $"Correct Answers: {Game.CorrectAnswersCount}";
        _menuButton.onClick.AddListener(MenuButton);
    }

    #endregion

    #region Private methods

    private void MenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    #endregion
}