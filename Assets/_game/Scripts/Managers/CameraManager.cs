using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    public static CameraManager sharedInstance = null;
    public CinemachineVirtualCamera virtualCamera;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }

        GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }
}