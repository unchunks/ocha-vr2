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

    [SerializeField] float moveSpeed; // 移動速度
    [SerializeField] float lowerSpeed; // 下限速度

    private float previousLeftHandPositionZ;
    private float previousRightHandPositionZ;
    private float leftHandVelocityZ;
    private float rightHandVelocityZ;
    private float leftHandDirectionZ;
    private float rightHandDirectionZ;
    private float rotateY;

    void Start()
    {
        // 初期位置を保存
        previousLeftHandPositionZ = leftHand.transform.position.z;
        previousRightHandPositionZ = rightHand.transform.position.z;
        
    }

    void Update()
    {
        // フレーム間の手の位置の変化を元に速度を計算
        leftHandVelocityZ =  ( leftHand.transform.position.z - previousLeftHandPositionZ) / Time.deltaTime;
        rightHandVelocityZ = (rightHand.transform.position.z - previousRightHandPositionZ) / Time.deltaTime;

        // 向いている角度を取得
        rotateY = centerEyeAnchor.transform.rotation.eulerAngles.y;
        
        // 手の速度の正負を取得
        leftHandDirectionZ = Mathf.Sign(leftHandVelocityZ);
        rightHandDirectionZ = Mathf.Sign(rightHandVelocityZ);

        // 向いている方向に移動
        if((300 < rotateY && rotateY <= 360) || (0 <= rotateY && rotateY < 60))
        {
            if(leftHandVelocityZ < -lowerSpeed)
            {
                Debug.Log("leftHandVelocityZ: " + leftHandVelocityZ);
            }
            if((leftHandDirectionZ == -1) && (leftHandVelocityZ < -lowerSpeed))
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocityZ * moveSpeed);
            }
            if((rightHandDirectionZ == -1) && (rightHandVelocityZ < -lowerSpeed))
            {
                cameraRig.transform.position += new Vector3(0, 0,  -rightHandVelocityZ * moveSpeed);
            }
        }
        else if((120 < rotateY && rotateY < 240))
        {
            if(leftHandVelocityZ > lowerSpeed)
            {
                Debug.Log("leftHandVelocityZ: " + leftHandVelocityZ);
            }
            if((leftHandDirectionZ == 1) && (leftHandVelocityZ > lowerSpeed))
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocityZ * moveSpeed);
            }
            if((rightHandDirectionZ == 1) && (rightHandVelocityZ > lowerSpeed))
            {
                cameraRig.transform.position += new Vector3(0, 0,  -rightHandVelocityZ * moveSpeed);
            }
        }

        // 現在の手の位置を次のフレームに向けて保存
        previousLeftHandPositionZ = leftHand.transform.position.z;
        previousRightHandPositionZ = rightHand.transform.position.z;
    }

    // 速度を外部から取得するためのメソッド
    public float GetLeftHandVelocity()
    {
        return leftHandVelocityZ;
    }

    public float GetRightHandVelocity()
    {
        return rightHandVelocityZ;
    }
}
