using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle,
    Walk,

}
public class BossEnemyBrain : MonoBehaviour
{
    public Brain<BossEnemyBrain> brain;
    public int coins = 0;
    public void Start()
    {
    }
}
