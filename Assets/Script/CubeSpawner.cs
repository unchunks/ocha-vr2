using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube; // CubeのGameObjectをインスペクターで設定

    // ボタンが押されたときに呼ばれるメソッド
    public void ToggleCube()
    {
        // Cubeのアクティブ状態を反転
        cube.SetActive(!cube.activeSelf);
    }
}

