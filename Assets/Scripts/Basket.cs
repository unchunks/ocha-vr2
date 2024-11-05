using UnityEngine;

public class Basket : MonoBehaviour
{
    public int score = 0; // 現在のスコア
    public int scoreValue = 10; // 加算/減算されるスコアの値
     // お茶の葉が籠に入ったとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeaLeaf"))
        {
            // 接触したオブジェクトの名前をコンソールに表示
            Debug.Log(other.gameObject.name + "がトリガーに入りました。");  
            score += scoreValue;
            Debug.Log("Tea Leaf entered! Score: " + score);
        }
    }

    // お茶の葉が籠から出たとき
    private void OnTriggerExit(Collider other)
    {
        
        
        if (other.CompareTag("TeaLeaf"))
        {
            Debug.Log(other.gameObject.name + "がトリガーから出ました。");  
            score -= scoreValue;
            Debug.Log("Tea Leaf exited! Score: " + score);
        }
    }
}
