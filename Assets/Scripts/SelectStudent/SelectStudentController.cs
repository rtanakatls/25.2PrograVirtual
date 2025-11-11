using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SelectStudentController : MonoBehaviour
{
    private const string url = "http://localhost/progravirtual252/library/get_student_by_name.php";

    public void SelectStudent(string name, Action<SelectStudentModel> onCallback)
    {
        StartCoroutine(SendRequest(name,onCallback));
    }

    private IEnumerator SendRequest(string name, Action<SelectStudentModel> onCallback)
    {
        WWWForm form=new WWWForm();
        form.AddField("name",name);

        using(UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if(www.result==UnityWebRequest.Result.Success)
            {
                SelectStudentModel selectStudentModel = JsonUtility.FromJson<SelectStudentModel>(www.downloadHandler.text);
                onCallback?.Invoke(selectStudentModel);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }


}
