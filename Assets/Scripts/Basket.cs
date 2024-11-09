using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Basket : MonoBehaviour
{
    [SerializeField] GameObject basket; // 籠のオブジェクト
    [SerializeField] int num_sheet = 0; // 現在のスコア

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
                    num_sheet += 1;
                }));
            }
            // 接触したオブジェクトの名前をコンソールに表示            
            Debug.Log("Tea Leaf entered! Score: " + num_sheet);
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
            num_sheet -= 1;
            Debug.Log("Tea Leaf exited! Score: " + num_sheet);
        }
    }

    //スコアを計算すべき
    public int GetScore()
    {
        return num_sheet;
    }
}
