using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public Transform leftSide;   // 왼쪽 저울 측면
    public Transform rightSide;  // 오른쪽 저울 측면
    public Rigidbody2D objectToWeigh;  // 무게를 측정할 물체의 Rigidbody2D

    private float startingRotation;  // 저울의 초기 회전값

    void Start()
    {
        // 저울의 초기 회전값을 저장
        startingRotation = transform.rotation.z;
    }

    void Update()
    {
        // 왼쪽 측면과 오른쪽 측면의 회전값 차이 계산
        float rotationDifference = leftSide.rotation.z - rightSide.rotation.z;

        // 물체의 무게 계산
        float objectWeight = objectToWeigh.mass;

        // 저울의 회전값 조절
        transform.rotation = Quaternion.Euler(0f, 0f, startingRotation + rotationDifference * objectWeight);
    }
}
