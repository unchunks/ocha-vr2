using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OculusSampleFramework;

public class ShakeMove : MonoBehaviour
{
    public GameObject cameraRig; // CameraRigのGameObject
    public OVRHand leftHand; // 左手のOVRHandコンポーネント
    public OVRHand rightHand; // 右手のOVRHandコンポーネント

    public GameObject centerEyeAnchor; // 移動させるのはカメラリグ、位置を取得するのはセンターアイアンカー

    private Vector3 previousLeftHandPosition;
    private Vector3 previousRightHandPosition;
    public Vector3 leftHandVelocity;
    public Vector3 rightHandVelocity;
    private float positiveLeftVelocity;
    private float positiveRightVelocity;
    private float positiveTotalVelocity;

    public float direction;
    private float handDirection;

    private float rotateY;

    // List<float> ArrayRotateList = new List<float>();


    void Start()
    {
        // 初期位置を保存
        previousLeftHandPosition = leftHand.transform.position;
        previousRightHandPosition = rightHand.transform.position;
        
    }

    void Update()
    {
        // フレーム間の手の位置の変化を元に速度を計算
        leftHandVelocity =  ( leftHand.transform.position - previousLeftHandPosition) / Time.deltaTime;
        rightHandVelocity = (rightHand.transform.position - previousRightHandPosition) / Time.deltaTime;
        
        // 手 - 頭 の正負
        // direction = Mathf.Sign(leftHand.transform.position.z - cameraRig.transform.position.z);

        // 頭 - 手 の正負
        direction = Mathf.Sign(centerEyeAnchor.transform.position.z - leftHand.transform.position.z);
        
        // 手の速度の正負を取得
        handDirection = Mathf.Sign(leftHandVelocity.z);
        
        // Debug.Log(cameraRig.transform.position.z  + "カメラリグの位置");

        // ArrayRotateList.Add(centerEyeAnchor.transform.rotation.eulerAngles.y);s

        rotateY = centerEyeAnchor.transform.rotation.eulerAngles.y;

        if((300 < rotateY && rotateY <= 360) || (0 <= rotateY && rotateY < 60))
        {
            if(handDirection == -1)
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocity.z * 0.02f);
            }
            
        }
        else if((120 < rotateY && rotateY < 240))
        {
            if(handDirection == 1)
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocity.z * 0.02f);
            }
        }

        // if(direction == -1 && handDirection ==-1)
        // {
        //     cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocity.z * 0.02f);
        // }
        // else if(direction == 1 && handDirection == 1)
        // {
        //     cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocity.z * 0.02f);
        // }



        // 現在の手の位置を次のフレームに向けて保存
        previousLeftHandPosition = leftHand.transform.position;
        previousRightHandPosition = rightHand.transform.position;
    }

    // 速度を外部から取得するためのメソッド
    public Vector3 GetLeftHandVelocity()
    {
        return leftHandVelocity;
    }

    public Vector3 GetRightHandVelocity()
    {
        return rightHandVelocity;
    }

    // public float MaxRotate()
    // {
    //     return ArrayRotateList.Max();
    // }
    // public float MinRotate()
    // {
    //     return ArrayRotateList.Min();
    // }
}
