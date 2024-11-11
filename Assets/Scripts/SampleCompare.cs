using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCompare : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Collider trueBasket; // 籠のオブジェクト  
    [SerializeField] Collider fakeBasket; // 籠のオブジェクト
    Collider myCollider; 
    void Start()
    {
        myCollider = GetComponent<Collider>();
        if(myCollider == trueBasket)
        {
            Debug.Log("ほんものです");
        }
        if(myCollider == fakeBasket)
        {
            Debug.Log("にせものです");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
