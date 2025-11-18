using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SendScoreView : MonoBehaviour
{
    [SerializeField] private Button button;

    [SerializeField] private TMP_InputField nameInputField;

    [SerializeField] private RankingView rankingView;
    private SendScoreController controller;

    private void Awake()
    {
        button.onClick.AddListener(OnClicked);
        controller = GetComponent<SendScoreController>();
    }

    private void OnClicked()
    {
        controller.SendScore(OnCallback, nameInputField.text, GameData.score);
    }

    private void OnCallback()
    {
        rankingView.GetRanking();
    }
}
