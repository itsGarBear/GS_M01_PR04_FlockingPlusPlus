using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoider : Kinematic
{
    AvoidCollision myMoveType;

    public Kinematic[] myTargets;

    void Start()
    {
        myMoveType = new AvoidCollision();
        myMoveType.myCharacter = this;
        myMoveType.myTargets = myTargets;

    }

    protected override void Update()
    {
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
}
