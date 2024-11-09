using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField inputField;
    [SerializeField]  PlayFabController playFabController;
    void Start()
    {
        // リトライ時に名前を入力済みにするための処理
        inputField.text = GameManager.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnterEnd()
    {
        // 3文字以上の名前がつけられたら
        if (inputField.text.Length > 2)
        {
            // 入力された名前をGameManagerに保存
            GameManager.playerName = inputField.text;
        }
        
        // 入力された名前をDBに保存
        playFabController.LogInPlayFab(GameManager.playerName);
    }
}
