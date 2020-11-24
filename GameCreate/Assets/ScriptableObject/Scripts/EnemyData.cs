﻿using UnityEngine;

[CreateAssetMenu(menuName = "SetData/Create EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public int atk;
    public int def;
    public int exp;
    public int gold;
}
