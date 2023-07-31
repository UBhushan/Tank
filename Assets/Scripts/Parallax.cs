using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxStrength;

    private Transform cam;
    private Vector3 camPriviousPosition;
    
    private void Start() {
        cam = Camera.main.transform;
        camPriviousPosition = cam.transform.position;
    }


    private void LateUpdate() {

        ParallaX();
        
        camPriviousPosition = cam.position;
    }

    private void ParallaX()
    {
        
        Vector2 parallaxOffset = (camPriviousPosition - cam.position) * parallaxStrength;
        parallaxOffset = new Vector2(transform.position.x + parallaxOffset.x, transform.position.y + parallaxOffset.y);

        transform.position = parallaxOffset;
        
    }

    
}
