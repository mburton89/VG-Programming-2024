using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBallPowerup : Powerup
{
    public override void GetCollected()
    {
        BallSpawner.Instance.SpawnMultiBall();
    }
}
