using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraScript : MonoBehaviour
    {
        private Quaternion position;
        private Quaternion rotation;
        private Quaternion tempPosition;
        private Quaternion tempRotation;

        private void Update()
        {
            CameraPosition();
            CameraRotation();
        }
        
        private void CameraPosition()
        {
            position = transform.rotation;
            if(position == tempPosition)return;
            EventManager.Instance.OnCameraChangedEvent(position);
            tempPosition = rotation;
        }

        private void CameraRotation()
        {
            rotation = transform.rotation;
            if(rotation == tempRotation)return;
            EventManager.Instance.OnCameraChangedRotationEvent(rotation);
            tempRotation = rotation;
        }


    }
}