using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance; 

    [SerializeField] private GameObject tankCam;
    [SerializeField] private GameObject enemyCam;
    [SerializeField] private ShotCam shotCam;

    [SerializeField] private float transitionDelay = 7f;

    private bool isTankCamOn = false;
    private bool isCircleMoving = false;

    private bool isEndCamOn = false;
    

    private void Awake() {

        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start() {
        Invoke("ChangeToTankCam", 2f);
        isEndCamOn = false;
    }

    public void ShakeShotCam()
    {
        shotCam.Shake();
    }

    public void ChangeToShotCam(Shot shot)
    {
        tankCam.SetActive(false);
        enemyCam.SetActive(false);
        shotCam.SetShot(shot);

        isTankCamOn = false;
    }

    public void ChangeToEnemyCam()
    {
        isTankCamOn = false;
        enemyCam.SetActive(true);

        Invoke(nameof(MovingCircle), transitionDelay);

    }

    private void MovingCircle()
    {
        if(isCircleMoving)
        {   

        }
        else
        {
            ChangeToTankCam();
        }
    }

    public void ChangeTOEndCam()
    {
        isEndCamOn = true;
        isTankCamOn = false;
        enemyCam.SetActive(true);
    }

    public void SetIsCircleMovingBool(bool isBoolParam)
    {
        isCircleMoving = isBoolParam;
    }



    public void ChangeToTankCam()
    {
        tankCam.SetActive(true);

        isTankCamOn = true;
    }

    public bool IsTankCameraOn()
    {
        return isTankCamOn;
    }

    public bool IsEndCamOn()
    {
        return isEndCamOn;
    }
}
