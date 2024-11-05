using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionStay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //OnCollisionStay関数
    private void OnCollisionStay(Collision collision){
 
        //SphereがPlaneと衝突している場合
        if (collision.gameObject.name == "Plane"){
            //Sphereの色を青にする
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
 
    //OnCollisionExit関数
    private void OnCollisionExit(Collision collision){
 
        //SphereがPlaneと離れた場合
        if(collision.gameObject.name == "Plane"){
            //Sphereの色を赤にする
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
