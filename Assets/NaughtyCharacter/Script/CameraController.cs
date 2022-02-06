﻿using System;
using CorePlugin.Attributes.Validation;
using CorePlugin.Cross.Events.Interface;
using GeneralEventType;
using UnityEngine;

namespace NaughtyCharacter.Script
{
    public class CameraController : MonoBehaviour, IEventSubscriber
    {
        [NotNull] [SerializeField] private Camera camera;
        [SerializeField] private float sensitivity = 100f;
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
            transform.localEulerAngles = new Vector3(xRotation, 0, 0);
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
