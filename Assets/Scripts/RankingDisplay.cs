using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> ranksList;
    [SerializeField] List<TextMeshProUGUI> namesList;
    [SerializeField] List<TextMeshProUGUI> scoresList;
    // Start is called before the first frame update
    public void setRanking(int rank, string name, string score)
    {
        // ランクは0から始まるので+1する
        ranksList[rank].text = (rank + 1).ToString();
        namesList[rank].text = name;
        scoresList[rank].text = score;
    }

    //minimum rankがあれば計算できる
    public void setAroundRanking(string rank, string name, string score)
    {
        
    }
}
