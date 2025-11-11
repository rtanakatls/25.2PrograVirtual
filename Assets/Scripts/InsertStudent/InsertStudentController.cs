using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class InsertStudentController : MonoBehaviour
{
    private const string url = "http://localhost/progravirtual252/library/insert_student.php"; 

    public void InsertStudent(string name, string lastName)
    { 
        StartCoroutine(SendRequest(name, lastName));
    }

    private IEnumerator SendRequest(string name, string lastName)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("lastname", lastName);

        using(UnityWebRequest www = UnityWebRequest.Post(url,form))
        {
            yield return www.SendWebRequest();

            if(www.result==UnityWebRequest.Result.Success)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
