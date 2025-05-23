using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum Type { Teleport, Linear, FeedbackLoop };
    [SerializeField] private Type type;
    [SerializeField] private Transform targetEntity;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float lerpSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetEntity == null) {
            PlayerScript go = FindAnyObjectByType<PlayerScript>();
            targetEntity = go.transform;
        }
        Vector3 currentTarget = GetTargetPosition();
        currentTarget.z = transform.position.z;
        currentTarget = currentTarget + offset;

        switch (type) {
            case Type.Teleport:
                transform.position = currentTarget;
                break;
            case Type.Linear:
                transform.position = Vector3.Lerp(transform.position, currentTarget, lerpSpeed * Time.deltaTime);
                break;
            case Type.FeedbackLoop: {
                Vector3 toTarget = currentTarget - transform.position;
                transform.position = Vector3.Lerp(transform.position, transform.position + toTarget * maxSpeed, lerpSpeed * Time.deltaTime);
            }
            break;
        }
    }
    Vector3 GetTargetPosition() 
    {
        return targetEntity.position;
    }
}