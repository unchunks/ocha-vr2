using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingDisplay : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> namesList;
    [SerializeField] List<TextMeshProUGUI> scoresList;

    [SerializeField] TextMeshProUGUI myRank;
    [SerializeField] TextMeshProUGUI myName;
    [SerializeField] TextMeshProUGUI myScore;
    // Start is called before the first frame update
    public void setRanking(int rank, string name, string score)
    {
        // ランクは0から始まる
        namesList[rank].text = name;
        scoresList[rank].text = score + "点";
    }

    //minimum rankがあれば計算できる
    public void setAroundRanking(string rank, string name, string score)
    {
        myRank.text = rank + "位";
        myName.text = name;
        myScore.text = score + "点";
    }
}
