using UnityEngine;

public class CubeToggle : MonoBehaviour
{
    // ボタンが押されたときに呼ばれるメソッド
    public void ToggleRenderer()
    {
        // Rendererコンポーネントを取得
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Rendererの有効/無効を切り替え
            renderer.enabled = !renderer.enabled;
        }
    }
}
