using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI oldScoreText;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button button;

    private CheckScoreController controller;

    private void Awake()
    {
        scoreText.text = $"Score: {GameData.score}";
        button.onClick.AddListener(OnClicked);
        controller = GetComponent<CheckScoreController>();
    }

    private void OnClicked()
    {
        controller.GetScore(OnResult, nameInputField.text);
    }

    private void OnResult(CheckScoreModel model)
    {
        if (model.data != null)
        {
            oldScoreText.text = $"Old Score: {model.data.score}";
        }
        else
        {
            oldScoreText.text = "New user";
        }
    }

}
