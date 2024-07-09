using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player; // プレイヤーのTransformへの参照
    public float verticalThreshold = 0.5f; // カメラの上半分のしきい値
    public float smoothSpeed = 0.125f; // カメラの移動スムーズ度

    private float maxCameraY; // カメラが到達した最大のY位置

    private void Start()
    {
        // カメラの初期Y位置を最大Y位置として設定
        maxCameraY = transform.position.y;
        player = FindObjectOfType<Player>().transform;
    }

    private void LateUpdate()
    {
        // プレイヤーが破壊されている場合は何もしない
        if (player == null)
        {
            return;
        }
        // カメラの現在の位置を計算
        Vector3 desiredPosition = transform.position;

        // プレイヤーがカメラの上半分以上に移動した場合
        if (player.position.y > transform.position.y + verticalThreshold)
        {
            // カメラの位置を上方向に調整
            float yDifference = player.position.y - (transform.position.y + verticalThreshold);
            desiredPosition.y += yDifference;

            // カメラの最大Y位置を更新
            if (desiredPosition.y > maxCameraY)
            {
                maxCameraY = desiredPosition.y;
            }
        }
        else
        {
            // プレイヤーがカメラの上半分より下にいる場合、カメラを最大Y位置に設定
            desiredPosition.y = maxCameraY;
        }

        // カメラをスムーズに移動
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}