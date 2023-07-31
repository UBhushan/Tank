using UnityEngine;

public class MuzzleFlashOnOff : MonoBehaviour
{
    public void EnableThis()
    {
        this.gameObject.SetActive(true);

        Invoke(nameof(DisableThis), 0.1f);
    }

    private void DisableThis()
    {
        this.gameObject.SetActive(false);
    }
}
