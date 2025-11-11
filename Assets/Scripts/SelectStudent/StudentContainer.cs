using UnityEngine;
using TMPro;

public class StudentContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI studentText;

    public void SetUp(string text)
    {
        studentText.text = text;
    }

}
