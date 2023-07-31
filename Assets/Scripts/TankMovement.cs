using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private Vector2 targetPosition;

    private void Start() {
        targetPosition = transform.position;
    }

    private void Update() {
        

        float motionMagnitude  = (targetPosition - TransformPosition2D()).magnitude;
        if(motionMagnitude > 0.05f)
        {
            Move();
        }
    }

    private void Move()
    {
        //transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime);
        Vector3 translateVector = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, transform.position.z).normalized ; 
        transform.Translate(translateVector * Time.deltaTime, Space.World);
    }

    [ContextMenu("Left")]
    private void TargetPositionLeft()
    {
        targetPosition = TransformPosition2D() - (Vector2.right * 1.5f); 
    }

    [ContextMenu("Right")]
    private void TargetPositionRight()
    {
        targetPosition = TransformPosition2D() + (Vector2.right * 1.5f);
    }

    private Vector2 TransformPosition2D()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
