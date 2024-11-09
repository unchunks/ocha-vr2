using PlayFab;
using PlayFab.ClientModels;
using System; //DateTimeを使用する為追加。
using System.Collections.Generic;
using UnityEngine;

public class PlayFabController : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    const string STATISTICS_NAME = "HighScore";

    private string debugString = "First";

    void Start()
    {
        
    }

    public void LogInPlayFab(string userName)
    {
        // 日付と時刻をIDにする
        if(GameManager.playerId == "")
        {
            GameManager.playerId = DateTime.Now.ToString();
        }


        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = GameManager.playerId, CreateAccount = true},
            result => {
                Debug.Log("ログイン成功！");
                SetUserName(userName);
            },
            error => Debug.Log("ログイン失敗"));
    }
    private void SetUserName(string userName)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = userName
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnSuccess, OnError);

        void OnSuccess(UpdateUserTitleDisplayNameResult result)
        {
            Debug.Log("success!");
        }

        void OnError(PlayFabError error)
        {
            Debug.Log($"{error.Error}");
        }
    }

    void Update()
    {
    }

    // スコア送信後にランキングを取得する
    public void SubmitScore(int playerScore)
    {
        Debug.Log("スコア送信するよお");
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = STATISTICS_NAME,
                        Value = playerScore
                    }
                }
            },
            result =>
            {
                Debug.Log("スコア送信完了です");
                RequestLeaderBoard();
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
                RequestLeaderBoard();
            }
        );
    }
    public void RequestLeaderBoard()
    {
        Debug.Log("ランキング取得するよ");
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = STATISTICS_NAME,
                StartPosition = 0,
                MaxResultsCount = 5
            },
            result =>
            {
                result.Leaderboard.ForEach(
                    x => {
                        
                        Debug.Log(string.Format("{0}位:{1} スコア{2}", x.Position + 1, x.DisplayName, x.StatValue));
                        debugString = string.Format("{0}位:{1} スコア{2}", x.Position + 1, x.DisplayName, x.StatValue);
                    }
                    );
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }




    public string GetDebugString()
    {
        return debugString;
    }

}