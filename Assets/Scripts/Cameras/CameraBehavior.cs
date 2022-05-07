using Cinemachine;
using UnityEngine;

namespace Cameras
{
    public class CameraBehavior : MonoBehaviour
    {
        private CinemachineVirtualCamera _cam;

        private void Awake()
        {
            _cam = GetComponent<CinemachineVirtualCamera>();
            _cam.m_Lens.NearClipPlane = -1000f;
        }
    }
}