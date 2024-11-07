using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OculusSampleFramework;

public class ShakeMove : MonoBehaviour
{
    [SerializeField] GameObject cameraRig; // CameraRigのGameObject
    [SerializeField] OVRHand leftHand; // 左手のOVRHandコンポーネント
    [SerializeField] OVRHand rightHand; // 右手のOVRHandコンポーネント

    [SerializeField] GameObject centerEyeAnchor; // 移動させるのはカメラリグ、位置を取得するのはセンターアイアンカー

    private Vector3 previousLeftHandPosition;
    private Vector3 previousRightHandPosition;
    private Vector3 leftHandVelocity;
    private Vector3 rightHandVelocity;
    private float positiveLeftVelocity;
    private float positiveRightVelocity;
    private float positiveTotalVelocity;

    private float leftHandDirection;
    private float rightHandDirection;

    private float rotateY;

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

        // 向いている角度を取得
        rotateY = centerEyeAnchor.transform.rotation.eulerAngles.y;
        
        // 手の速度の正負を取得
        leftHandDirection = Mathf.Sign(leftHandVelocity.z);
        rightHandDirection = Mathf.Sign(rightHandVelocity.z);

        // 向いている方向に移動
        if((300 < rotateY && rotateY <= 360) || (0 <= rotateY && rotateY < 60))
        {
            if(leftHandDirection == -1)
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocity.z * 0.01f);
            }
            if(rightHandDirection == -1)
            {
                cameraRig.transform.position += new Vector3(0, 0,  -rightHandVelocity.z * 0.01f);
            }
        }
        else if((120 < rotateY && rotateY < 240))
        {
            if(leftHandDirection == 1)
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocity.z * 0.01f);
            }
            if(rightHandDirection == 1)
            {
                cameraRig.transform.position += new Vector3(0, 0,  -rightHandVelocity.z * 0.01f);
            }
        }

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
}
