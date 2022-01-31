using CorePlugin.Attributes.Validation;
using CorePlugin.Cross.Events.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Enemies
{
    [RequireComponent(typeof(Canvas))]
    public class HealthBar : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] [NotNull] private Canvas canvas;
        [SerializeField] [NotNull] private TextMeshProUGUI text;
        private int _currentHealth, _maxHealth;
        private void Reset()
        {
            canvas ??= GetComponent<Canvas>();
        }

        private void UpdateText(int damage, int currentHealth)
        {
            _currentHealth = currentHealth;
            text.text = currentHealth.ToString();
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (EnemiesDelegates.UIReceiveDamage)UpdateText
            };
        }
    }
}
