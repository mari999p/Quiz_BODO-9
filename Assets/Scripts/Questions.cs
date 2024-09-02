using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class Question : ScriptableObject
{
    #region Variables

    [TextArea(5, 10)] [SerializeField] private string _questionLabel;
    [SerializeField] private string[] _answerOptions;
    [SerializeField] private int _correctAnswer;

    #endregion

    #region Properties

    public string[] AnswerOptions => _answerOptions;
    public int CorrectAnswer => _correctAnswer;

    public string QuestionLabel => _questionLabel;

    #endregion
}