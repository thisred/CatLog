using UnityEngine;

public class TrueCamera : MonoBehaviour
{
    public Transform target = null; // 目标玩家
    [Range(10, 90)] public float initialAngle = 40f; // 初始俯视角度
    [Range(10, 90)] public float maxVerticalAngle = 50f; // 最高俯视角度
    [Range(10, 90)] public float minVerticalAngle = 35f; // 最低俯视角度

    float initialDistance; // 初始化相机与玩家的距离 根据角度计算
    [Range(1, 100)] public float maxDistance = 20f; // 相机距离玩家最大距离
    [Range(1, 100)] public float minDistance = 5f; // 相机距离玩家最小距离
    [Range(1, 100)] public float zoomSpeed = 50; // 缩放速度
    [Range(1f, 200)] public float swipeSpeed = 50; // 左右滑动速度

    float scrollWheel; // 记录滚轮数值
    float tempAngle; // 临时存储摄像机的初始角度
    Quaternion _gravityAlignment = Quaternion.identity; // 重力对准
    [SerializeField, Min(0f)] float upAlignmentSpeed = 360f;
    [SerializeField] private Vector2 orbitAngles = new Vector2(45f, 0f);
    [SerializeField, Range(1f, 100f)] float rotationSpeed = 15f;

    void Start()
    {
        Input.multiTouchEnabled = true;
        InitCamera();
    }

    void Update()
    {
        ZoomCamera();
        SwipeScreen();
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void InitCamera()
    {
        tempAngle = initialAngle;
        initialDistance = Mathf.Sqrt((initialAngle - minVerticalAngle) / Calculate()) + minDistance;
        initialDistance = Mathf.Clamp(initialDistance, minDistance, maxDistance);
    }

    void FollowPlayer()
    {
        var fromUp = _gravityAlignment * Vector3.up;
        var toUp = target.position; // 获取重力相反方向
        float dot = Mathf.Clamp(Vector3.Dot(fromUp, toUp), -1f, 1f);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        float maxAngle = upAlignmentSpeed * Time.deltaTime;

        var newAlignment = Quaternion.FromToRotation(fromUp, toUp) * _gravityAlignment;
        _gravityAlignment = angle <= maxAngle
            ? newAlignment
            : Quaternion.SlerpUnclamped(_gravityAlignment, newAlignment, maxAngle / angle);

        var orbitRotation = Quaternion.Euler(orbitAngles);
        var lookRotation = _gravityAlignment * orbitRotation;
        var lookDirection = lookRotation * Vector3.forward;
        var lookPosition = target.position - lookDirection * initialDistance;
        transform.SetPositionAndRotation(lookPosition, lookRotation);
    }

    void ZoomCamera()
    {
        scrollWheel = GetZoomValue();
        if (scrollWheel != 0)
        {
            tempAngle = initialAngle - scrollWheel * 2 * (maxVerticalAngle - minVerticalAngle);
            tempAngle = Mathf.Clamp(tempAngle, minVerticalAngle, maxVerticalAngle);
        }

        if (Mathf.Abs(tempAngle - initialAngle) > 0.001f)
        {
            initialAngle = Mathf.Lerp(initialAngle, tempAngle, Time.deltaTime * 10);
            initialDistance = Mathf.Sqrt((initialAngle - minVerticalAngle) / Calculate()) + minDistance;
            initialDistance = Mathf.Clamp(initialDistance, minDistance, maxDistance);
        }
    }

    float Calculate()
    {
        float dis = maxDistance - minDistance;
        float ang = maxVerticalAngle - minVerticalAngle;
        return ang / (dis * dis);
    }

    bool isMousePress = false;
    Vector2 oldMousePos;
    Vector2 newMousePos;
    Vector2 mousePosOffset;

    void SwipeScreen()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            oldMousePos = Vector2.zero;
            isMousePress = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mousePosOffset = Vector2.zero;
            isMousePress = false;
        }

        if (!isMousePress)
            return;

        newMousePos = Input.mousePosition;
        if (oldMousePos != Vector2.zero)
        {
            mousePosOffset = newMousePos - oldMousePos;
            ManualRotation(new Vector2(-mousePosOffset.y, -mousePosOffset.x));
        }

        oldMousePos = newMousePos;
    }

    void ManualRotation(Vector2 input)
    {
        const float e = 0.001f;
        if (input.x < -e || input.x > e || input.y < -e || input.y > e)
        {
            orbitAngles += rotationSpeed * Time.unscaledDeltaTime * input;
            ConstrainAngles();
        }
    }

    void ConstrainAngles()
    {
        orbitAngles.x = Mathf.Clamp(orbitAngles.x, minVerticalAngle, maxVerticalAngle);

        if (orbitAngles.y < 0f)
        {
            orbitAngles.y += 360f;
        }
        else if (orbitAngles.y >= 360f)
        {
            orbitAngles.y -= 360f;
        }
    }

    float GetZoomValue()
    {
        float zoomValue = 0;
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            zoomValue = Input.GetAxis("Mouse ScrollWheel");
        }

        return zoomValue;
    }
}