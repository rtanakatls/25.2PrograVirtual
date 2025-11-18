using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RankingController : MonoBehaviour
{
    private const string url = "http://localhost/progravirtual252/game1/get_ranking.php";

    public void GetRanking(Action<RankingModel> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<RankingModel> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<RankingModel>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
