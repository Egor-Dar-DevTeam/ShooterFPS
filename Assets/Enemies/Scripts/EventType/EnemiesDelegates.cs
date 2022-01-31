using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies {
    public static class EnemiesDelegates
    {
        public delegate void UIReceiveDamage(int damage, int currentHealth);
        public delegate void UIStart(int maxHealth, int currentHealth);
    }
}
