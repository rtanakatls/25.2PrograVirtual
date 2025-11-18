using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class CheckScoreController : MonoBehaviour
{
    private const string url = "http://localhost/progravirtual252/game1/get_user_by_name.php";

    public void GetScore(Action<CheckScoreModel> callback, string username)
    {
        StartCoroutine(SendRequest(callback, username));
    }

    private IEnumerator SendRequest(Action<CheckScoreModel> callback, string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);

        using(UnityWebRequest www = UnityWebRequest.Post(url,form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<CheckScoreModel>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
