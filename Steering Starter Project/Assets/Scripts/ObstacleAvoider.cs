using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : Kinematic
{
    AvoidObstacle myMoveType;
    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new AvoidObstacle();
        myMoveType.character = this;
        myMoveType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
}
