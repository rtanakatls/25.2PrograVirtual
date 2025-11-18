using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SendScoreController : MonoBehaviour
{
    private const string url = "http://localhost/progravirtual252/game1/upload_score.php";

    public void SendScore(Action callback, string username, int score)
    {
        StartCoroutine(SendRequest(callback, username, score));
    }

    private IEnumerator SendRequest(Action callback, string username, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("score", score);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke();
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
