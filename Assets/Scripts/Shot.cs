using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float groundContactSpeedMultiplier= 0.1f;
    private Rigidbody2D rigidbody2d;

    [SerializeField] private AudioClip poof;
    private void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 force)
    {
        Vector2 linearForce = new Vector2(Mathf.Sqrt(force.x), Mathf.Sqrt(force.y));
        float magnitudeMultiplier = 10f;
        rigidbody2d.AddForce(linearForce * magnitudeMultiplier);

    }
        

    private void ChangeCam() {
        if(CameraManager.instance != null && !CameraManager.instance.IsEndCamOn())
        {
            CameraManager.instance.ChangeToEnemyCam();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "ground")
        {
            rigidbody2d.velocity *= groundContactSpeedMultiplier;
            SoundManager.instance.PlayAudioFx(poof); 
        }

        if(CameraManager.instance != null)
        {
            CameraManager.instance.ShakeShotCam();
            Invoke(nameof(ChangeCam), 0.245f);
            Destroy(this.gameObject, 5f);
        }
    }
         
    
}
