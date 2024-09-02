using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text _resultLabel;
    [SerializeField] private Button _menuButton;
    private void Start()
    {
        _resultLabel.text = $"Correct Answers: {Game.CorrectAnswersCount}";
        _menuButton.onClick.AddListener(MenuButton);
    }

   

    private void MenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
