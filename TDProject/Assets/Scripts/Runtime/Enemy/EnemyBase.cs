using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
   public float Health {get; set;}
   public float Speed  {get; set;}
   public float Damage {get; set;}

   public abstract void TakeDamage(float damage);
   public abstract void OnDeath();
   public abstract void Movement();
}
