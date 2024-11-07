using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Basket : MonoBehaviour
{
    [SerializeField] GameObject basket; // 籠のオブジェクト
    public int score = 0; // 現在のスコア
    public int scoreValue = 10; // 加算/減算されるスコアの値

    private GameObject obj;
    private Rigidbody rb;
    private BoxCollider bocol;

     // お茶の葉が籠に入ったとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeaLeaf"))
        {
            obj = other.gameObject;
            rb = obj.GetComponent<Rigidbody>();
            if (rb.isKinematic == false)
            {
                
                Debug.Log(other.gameObject.name + "がトリガーに入りました。");  
                StartCoroutine(DelayCoroutine(0.4f, () => {
                    bocol = obj.GetComponent<BoxCollider>();
                    bocol.enabled = false;
                    rb.isKinematic = true;
                    obj.transform.parent = basket.transform;
                    score += scoreValue;
                }));
            }
            // 接触したオブジェクトの名前をコンソールに表示            
            Debug.Log("Tea Leaf entered! Score: " + score);
        }
    }
    private IEnumerator DelayCoroutine(float seconds, UnityAction callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
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
