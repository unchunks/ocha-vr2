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

    public void OnEnterEnd()
    {
        // 3文字以上の名前がつけられたら
        if (inputField.text.Length > 2)
        {
            // 入力された名前をGameManagerに保存
            GameManager.playerName = inputField.text;
        }
        else
        {
            // 3文字未満の場合は名前を入力してくださいと表示
            GameManager.playerName = "名も無き茶摘み人";
        }

        // 入力された名前をDBに保存
        playFabController.LogInPlayFab(GameManager.playerName);
    }
}
