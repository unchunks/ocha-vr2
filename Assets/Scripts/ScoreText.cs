using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private PlayFabController playFabController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  playFabController.GetDebugString();
    }

    public void SetScore(int score)
    {
    }
}
