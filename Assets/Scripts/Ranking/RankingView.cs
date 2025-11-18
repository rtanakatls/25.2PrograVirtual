using UnityEngine;

public class RankingView : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    private RankingController controller;

    private void Awake()
    {
        controller = GetComponent<RankingController>();
    }

    public void GetRanking()
    {
        controller.GetRanking(OnResult);
    }

    private void OnResult(RankingModel model)
    {
        foreach(Transform t in container.GetComponentInChildren<Transform>())
        {
            if(t!=container.transform)
            {
                Destroy(t.gameObject);
            }
        }

        foreach(UserRankingModel user in model.data)
        {
            GameObject obj= Instantiate(prefab, container);
            obj.GetComponent<UserRanking>().Set($"{user.user_id} - {user.username} - {user.score}");
        }
    }
    

}
