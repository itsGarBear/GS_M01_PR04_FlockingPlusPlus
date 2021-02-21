using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCollision : SteeringBehavior
{
    public Kinematic myCharacter;
    public float maxAcceleration = 1f;

    public Kinematic[] myTargets;

    public float radius = .1f;
    public override SteeringOutput getSteering()
    {
        Kinematic firstTarget = null;

        float firstCollisionTime = float.PositiveInfinity;
        float firstDistance = float.PositiveInfinity;
        float firstSeparation = float.PositiveInfinity;
        Vector3 firstPos = Vector3.positiveInfinity;
        Vector3 firstVel = Vector3.zero;

        Vector3 relativePosition = Vector3.positiveInfinity;
        foreach(Kinematic target in myTargets)
        {
            relativePosition = target.transform.position - myCharacter.transform.position;

            Vector3 relativeVelocity = myCharacter.linearVelocity - target.linearVelocity;
            float relativeSpeed = relativeVelocity.magnitude;

            float collisionTime = (Vector3.Dot(relativePosition, relativeVelocity) / Mathf.Pow(relativeSpeed, 2));

            float distance = relativePosition.magnitude;

            float minSeparation = distance - (relativeSpeed * collisionTime);

            if (minSeparation > 2 * radius)
                continue;

            if(collisionTime > 0 && collisionTime < firstCollisionTime)
            {
                firstCollisionTime = collisionTime;
                firstTarget = target;
                firstSeparation = minSeparation;
                firstDistance = distance;
                firstPos = relativePosition;
                firstVel = relativeVelocity;
            }
        }

        if (firstTarget == null)
            return null;


        SteeringOutput result = new SteeringOutput();

        float dotProduct = Vector3.Dot(myCharacter.linearVelocity.normalized, firstTarget.linearVelocity.normalized);

        if (dotProduct < -0.9)
            result.linear = firstTarget.transform.right;
        else
            result.linear = -firstTarget.linearVelocity;

        result.linear.Normalize();
        result.linear *= maxAcceleration;
        result.angular = 0;
        return result;
    }
}
