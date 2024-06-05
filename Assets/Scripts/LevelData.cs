using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    public int CurrentLevel;
    public int CurrentSkin;
    public Level[] Levels;
    public Skin[] Skins;

    public Level GetCurrentLvl()
    {
        return Levels[CurrentLevel];
    }

    public Skin GetCurrentSkin()
    {
        return Skins[CurrentSkin];
    }
}

[Serializable]
public struct Level
{
    public float BoxSpeed;
    public int NeedCountBalls;
    public GameObject LevelObj;
}

[Serializable]
public struct Skin
{
    public Sprite Ball;
    public Sprite Gun;
    public Sprite Box;
}