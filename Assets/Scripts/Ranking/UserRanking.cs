using TMPro;
using UnityEngine;

public class UserRanking : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userText;

    public void Set(string text)
    {
        userText.text = text;
    }

}
