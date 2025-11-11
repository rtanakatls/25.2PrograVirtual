using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectStudentView : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchInputField;
    [SerializeField] private Button searchButton;


    [SerializeField] private GameObject container;
    [SerializeField] private GameObject studentPrefab;

    private SelectStudentController controller;

    private void Awake()
    {
        controller = GetComponent<SelectStudentController>();
        searchButton.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        controller.SelectStudent(searchInputField.text,OnCallback);
    }

    private void OnCallback(SelectStudentModel model)
    {
        if(model.message=="success")
        {
            foreach(Transform child in container.transform)
            {
                if (child != container.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            foreach(StudentModel student in model.data)
            {
                GameObject obj=Instantiate(studentPrefab,container.transform);
                obj.GetComponent<StudentContainer>().SetUp($"{student.name} - {student.lastname}");
            }
        }
        else
        {
            Debug.Log("error");
        }
    }

}
