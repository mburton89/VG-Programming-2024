using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiball : PowerUp
{
    public override void GetCollected()
    {
        BallSpawner.Instance.spawnDVDPlayer();


    }

  
}
