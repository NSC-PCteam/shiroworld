using UnityEngine;

[ExecuteInEditMode, DisallowMultipleComponent]
public class CameraController : MonoBehaviour
{
    public Transform target;

    [SerializeField] private float distance = 20.0f;
    [SerializeField] private float polarAngle = 45.0f;
    [SerializeField] private float azimuthalAngle = 45.0f;

    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float maxDistance = 100.0f;
    [SerializeField] private float minPolarAngle = 5.0f;
    [SerializeField] private float maxPolarAngle = 75.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    private Vector3 offset;
    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }
    void LateUpdate()
{
    // 右ドラッグでカメラの回転
    if (Input.GetMouseButton(1))
    {
        updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    // マウスホイールでの拡大縮小
    updateDistance(Input.GetAxis("Mouse ScrollWheel"));

    // WASDキーでの移動
    Vector3 moveDirection = Vector3.zero;
    if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward; // 前
    if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left; // 左
    if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back; // 後
    if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right; // 右

    // Up/Down arrow movement
    if (Input.GetKey(KeyCode.UpArrow)) {
        moveDirection += Vector3.up; // 上
    }
    if (Input.GetKey(KeyCode.DownArrow)) {
        moveDirection += Vector3.down; // 下
    }

    // カメラのローカル座標で移動
    if (moveDirection.magnitude > 0)
    {
        Vector3 move = transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime;
        transform.position += move;
    }

    // カメラ位置の更新
    updatePosition();

    // ターゲットを見続ける
    if (target != null)
    {
        transform.LookAt(target.position);
    }
}

    void updateAngle(float x, float y)
    {
        azimuthalAngle -= x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(azimuthalAngle, 360);

        polarAngle += y * mouseYSensitivity;
        polarAngle = Mathf.Clamp(polarAngle, minPolarAngle, maxPolarAngle);
    }

    void updateDistance(float scroll)
    {
        distance -= scroll * scrollSensitivity;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    void updatePosition()
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;

        // ターゲットの位置を基準にカメラを配置
        Vector3 targetPosition = target != null ? target.position : Vector3.zero;
        transform.position = new Vector3(
            targetPosition.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            targetPosition.y + distance * Mathf.Cos(dp),
            targetPosition.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
}
