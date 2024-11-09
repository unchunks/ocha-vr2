using TMPro;
using UnityEngine;

public class UseKeyboard : MonoBehaviour
{
    // InputField の読み込み
    [SerializeField] private TMP_InputField inputField;
    
    // 保存先
    private string Output;

    public bool isOpen = false;

    // キーボードの宣言
    private TouchScreenKeyboard _overlayKeyboard;

    // キーボードの変更時のみ動く
    private void Update()
    {
        if (_overlayKeyboard.text == "") return;

        if (isOpen)
        {
            //inputPassFieldになってたけど
            inputField.text = _overlayKeyboard.text;
            Output = inputField.text;
        }
    }

    // キーボードを呼び出す関数
    public void SetKeyboard()
    {
        Debug.Log("キーボードを呼び出します");
        _overlayKeyboard = TouchScreenKeyboard.Open(Output, TouchScreenKeyboardType.URL);
        isOpen = true;
    }
}
