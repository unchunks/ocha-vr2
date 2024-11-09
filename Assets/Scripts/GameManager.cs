using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static string playerId;
    public static string playerName;

    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private ShakeMove shakeMove;
    [SerializeField] private TimerSlider timerSlider;
    float countDownTime = 3.0f;

    public enum GameStatus
    {
          PREVSTART,    // グー
          COUNTDOWNING,  // チョキ
          FINISHED,    // パー
    }

    private GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameStatus.PREVSTART;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStatus == GameStatus.COUNTDOWNING)
        {
            countDownTime -= Time.deltaTime;
            countDownText.text = countDownTime.ToString("F0");
            if(countDownTime < 0)
            {
                StartGame();
                countDownText.text = "";
            }
        }
    }

    public void StartCountDown()
    {
        gameStatus = GameStatus.COUNTDOWNING;
    }

    void StartGame()
    {
        gameStatus = GameStatus.FINISHED;
        // 動けるようにする
        shakeMove.onCanMove();

        // タイマー開始
        timerSlider.onTimerStart();
    }

}
