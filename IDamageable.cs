using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    event Action OnKilled;
    void TakeHit(int damage);
    void Killed();
}
