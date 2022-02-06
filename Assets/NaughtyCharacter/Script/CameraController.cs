using System;
using CorePlugin.Cross.Events.Interface;
using GeneralEventType;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public class CameraController : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] private float sensitivity = 100f;
        [SerializeField] private Camera camera;
        private Camera GetCamera() => camera;
        
        private float xRotation = 0f;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        private void CameraUpdate(Vector2 axis)
        {
            var mouseX = axis.x * sensitivity * Time.deltaTime;
            var mouseY = axis.y * sensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);
            transform.localRotation=Quaternion.Euler(xRotation,0f,0f);
            transform.parent.transform.Rotate(Vector3.up*mouseX);
        }
        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.SetCameraInput) CameraUpdate,
                (GeneralEventDelegates.GetCamera) GetCamera
            };
        }
    }
}