using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Shot shot;
    [SerializeField] private AnimShoot animShoot;

    [SerializeField] private MuzzleFlashOnOff muzzle;

    [SerializeField] private AudioClip shootSoundfx;

    [SerializeField] private GameObject shootButton;
    
    private float magnitude = 0f;
    private Vector3 angle;
    private float magnitudeMultiplier = 200f;

    private void Start() {
        angle = Vector3.zero;
    }

    private void Update() {
        if(CameraManager.instance != null)
        {
            shootButton.SetActive(CameraManager.instance.IsTankCameraOn());
        }

    }

    
    
    [ContextMenu("shoot")]
    public void shootit() {
        Shot shotobj = Instantiate(shot, shootPoint.position, Quaternion.identity);
        Vector2 forceAngle = shootPoint.position - transform.position;
        if(CameraManager.instance != null)
            CameraManager.instance.ChangeToShotCam(shotobj);
        shotobj.Shoot(forceAngle.normalized * magnitude * magnitudeMultiplier);

        

        animShoot.ShootAnim();
        muzzle.EnableThis();
        
        SoundManager.instance.PlayAudioFx(shootSoundfx);
    }

    public void SetPower(float value)
    {
        magnitude = value;
    }


    public void SetAngle(float value)
    {
        angle.z = value; 
        transform.eulerAngles = angle;
    }

}
