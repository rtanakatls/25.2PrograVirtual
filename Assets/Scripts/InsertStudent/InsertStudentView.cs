using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InsertStudentView : MonoBehaviour
{
    [SerializeField] private TMP_InputField studentNameInput;
    [SerializeField] private TMP_InputField studentLastNameInput;
    [SerializeField] private Button sendButton;

    private InsertStudentController controller;

    private void Awake()
    {
        controller=GetComponent<InsertStudentController>();
        sendButton.onClick.AddListener(OnClicked);  
    }

    private void OnClicked()
    {
        string name=studentNameInput.text;
        string lastName=studentLastNameInput.text;
        controller.InsertStudent(name,lastName);
    }


}
