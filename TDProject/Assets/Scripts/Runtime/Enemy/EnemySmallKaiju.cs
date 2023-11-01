using System;
using TMPro;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemySmallKaiju : EnemyBase
    {
        public  void Start()
        {
            Health = 100;
            Speed = 10f;
            Damage = 5f;
        }

        public override void TakeDamage(float damage)
        {
        }

        public override void OnDeath()
        {
        }

        public override void Movement()
        {
        }
    }
}