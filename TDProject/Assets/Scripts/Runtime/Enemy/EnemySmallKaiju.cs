using System;
using Runtime.SOScripts.EnemySO;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Enemy
{
    public class EnemySmallKaiju : EnemyBase
    {
        [SerializeField] private EnemySoScript enemySoScript;
        public  void Start()
        {
            Health = enemySoScript.healthValue;
            Speed = enemySoScript.speedValue;
            Damage = enemySoScript.damageValue;
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