using System;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public class CameraController : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] private float sensitivity = 100f;

        [SerializeField] [Range(0, 1)] private float dump;
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
            transform.localEulerAngles = new Vector3(xRotation, 0, 0);
            //transform.parent.transform.localRotation =Quaternion.Lerp(transform.localRotation, Quaternion.Euler(new Vector3(mouseX,0,0)), dump);
        }
        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerEventDelegates.SetCameraInput) CameraUpdate
            };
        }
    }
}
