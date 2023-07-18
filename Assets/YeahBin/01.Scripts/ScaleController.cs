using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public Transform leftSide;   // ���� ���� ����
    public Transform rightSide;  // ������ ���� ����
    public Rigidbody2D objectToWeigh;  // ���Ը� ������ ��ü�� Rigidbody2D

    private float startingRotation;  // ������ �ʱ� ȸ����

    void Start()
    {
        // ������ �ʱ� ȸ������ ����
        startingRotation = transform.rotation.z;
    }

    void Update()
    {
        // ���� ����� ������ ������ ȸ���� ���� ���
        float rotationDifference = leftSide.rotation.z - rightSide.rotation.z;

        // ��ü�� ���� ���
        float objectWeight = objectToWeigh.mass;

        // ������ ȸ���� ����
        transform.rotation = Quaternion.Euler(0f, 0f, startingRotation + rotationDifference * objectWeight);
    }
}
