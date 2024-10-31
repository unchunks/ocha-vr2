using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube; // CubeのGameObjectをインスペクターで設定
    private Rigidbody rb;
    void Start()
    {
        rb = cube.GetComponent<Rigidbody>();
    }
    public void OnGrabkobayashi()
    {
        rb.isKinematic = false;
        // Use Gravityをオンにする
        // rb.useGravity = true;
    }
    // ボタンが押されたときに呼ばれるメソッド
    // public void ToggleCube()
    // {
    //     // Cubeのアクティブ状態を反転
    //     cube.SetActive(!cube.activeSelf);
        
    // }
}

