using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OculusSampleFramework;

public class ShakeMove : MonoBehaviour
{
    [SerializeField] GameObject cameraRig; // CameraRigのGameObject
    [SerializeField] Rigidbody cameraRb; // Rigidbodyコンポーネント
    [SerializeField] OVRHand leftHand; // 左手のOVRHandコンポーネント
    [SerializeField] OVRHand rightHand; // 右手のOVRHandコンポーネント

    [SerializeField] GameObject centerEyeAnchor; // 移動させるのはカメラリグ、位置を取得するのはセンターアイアンカー


    [SerializeField] float moveSpeed; // 移動速度
    [SerializeField] float lowerSpeed; // 下限速度
    [SerializeField] float upperSpeed; // 上限速度

    private float previousLeftHandPositionZ;
    private float previousRightHandPositionZ;
    private float leftHandVelocityZ;
    private float rightHandVelocityZ;
    private float leftHandDirectionZ;
    private float rightHandDirectionZ;
    private float rotateY;

    private bool isLeftHandWristDown = false;
    private bool isRightHandWristDown = false;

    private bool canMove = false;



    void Start()
    {
        // 初期位置を保存
        previousLeftHandPositionZ = leftHand.transform.position.z;
        previousRightHandPositionZ = rightHand.transform.position.z;
        
    }

    void Update()
    {
        // スタートを押したら動ける
        if(canMove)
        {
            Move();
        }
    }

    void Move(){
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
            // 左手が下向きで速度が下限速度より大きく引く動きをしたとき
            if(isLeftHandWristDown && (leftHandDirectionZ == -1) && (leftHandVelocityZ < -lowerSpeed) )
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocityZ * moveSpeed);
                // cameraRb.AddForce(0, 0, -leftHandVelocityZ * moveSpeed); 
                // cameraRb.velocity = new Vector3(0, 0, -rightHandVelocityZ * moveSpeed);
            }
            if(isRightHandWristDown && (rightHandDirectionZ == -1) && (rightHandVelocityZ < -lowerSpeed))
            {
                cameraRig.transform.position += new Vector3(0, 0,  -rightHandVelocityZ * moveSpeed);
                // cameraRb.velocity = new Vector3(0, 0, -rightHandVelocityZ * moveSpeed);
            }
        }
        else if((120 < rotateY && rotateY < 240))
        {
            if(isLeftHandWristDown && (leftHandDirectionZ == 1) && (leftHandVelocityZ > lowerSpeed))
            {
                cameraRig.transform.position += new Vector3(0, 0,  -leftHandVelocityZ * moveSpeed);
                // cameraRb.velocity = new Vector3(0, 0, -rightHandVelocityZ * moveSpeed);
            }
            if(isRightHandWristDown && (rightHandDirectionZ == 1) && (rightHandVelocityZ > lowerSpeed))
            {
                cameraRig.transform.position += new Vector3(0, 0,  -rightHandVelocityZ * moveSpeed);
                // cameraRb.velocity = new Vector3(0, 0, -rightHandVelocityZ * moveSpeed);
            }
        }

        // 現在の手の位置を次のフレームに向けて保存
        previousLeftHandPositionZ = leftHand.transform.position.z;
        previousRightHandPositionZ = rightHand.transform.position.z;
    }

    public void onLeftHandWristDown()
    {
        isLeftHandWristDown = true;
    }
    public void offLeftHandWristDown()
    {
        isLeftHandWristDown = false;
    }
    public void onRightHandWristDown()
    {
        isRightHandWristDown = true;
    }
    public void offRightHandWristDown()
    {
        isRightHandWristDown = false;
    }

    public void onCanMove()
    {
        canMove = true;
    }
}
