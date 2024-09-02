using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<Question> _questions;
    [SerializeField] private Button[] _answerButtons;
    [SerializeField] private TMP_Text _questionLabel;
    [SerializeField] private TMP_Text _lives;
    [SerializeField] private int _currentLives = 3;
    [SerializeField] private Color _defaultColor;

    [SerializeField] private List<Question> _askedQuestions = new();

    #endregion

    #region Properties

    public static int CorrectAnswersCount { get; private set; }

    #endregion

   
    private void Start()
    {
        DisplayQuestion();
        UpdateLives();

    }
    private void DisplayQuestion()
    {
        if (_askedQuestions.Count >= _questions.Count)
        {
            SceneManager.LoadScene("EndScene");
            return;
        }

        Question randomQuestion = GetRandomQuestion();
        _askedQuestions.Add(randomQuestion);

        _questionLabel.text = randomQuestion.QuestionLabel;
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            int index = i;
            _answerButtons[i].GetComponentInChildren<TMP_Text>().text = randomQuestion.AnswerOptions[i];
            _answerButtons[i].onClick.RemoveAllListeners();
            _answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index, randomQuestion.CorrectAnswer));
            _answerButtons[i].GetComponent<Image>().color = _defaultColor;
        }
    }
    private Question GetRandomQuestion()
    {
        int randomQustion;
        do
        {
            randomQustion = Random.Range(0, _questions.Count);
        }
        while (_askedQuestions.Contains(_questions[randomQustion]));

        return _questions[randomQustion];
    }
    private void OnAnswerSelected(int selectedAnswer, int correctedAnswer)
    {
        if (selectedAnswer == correctedAnswer)
        {
            CorrectAnswersCount++;
            _answerButtons[selectedAnswer].GetComponent<Image>().color = Color.green;
        }
        else
        {
            _currentLives--;
            _lives.text = $"Lives: {_currentLives}";
            _answerButtons[selectedAnswer].GetComponent<Image>().color = Color.red;
            if (_currentLives <= 0)
            {
                SceneManager.LoadScene("EndScene");
                return;
            }
        }

        Invoke(nameof(DisplayQuestion), 1f);
    }
    private void UpdateLives()
    {
        _lives.text = $"Lives: {_currentLives}";
    }
}