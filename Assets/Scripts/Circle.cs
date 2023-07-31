using UnityEngine;

public class Circle : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(!CameraManager.instance.IsTankCameraOn())
        {
            MovingCircle();
        }
    }

    public void MovingCircle()
    {
        if(rb.velocity.magnitude > 0)
        {
            CameraManager.instance.SetIsCircleMovingBool(true);
        }
        else    
        {
            CameraManager.instance.SetIsCircleMovingBool(false);
        }
    }
}
