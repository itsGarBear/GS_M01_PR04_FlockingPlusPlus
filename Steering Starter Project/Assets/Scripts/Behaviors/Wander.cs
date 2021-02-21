using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehavior
{
    public Kinematic character;

    float maxAcceleration = 1f;

    protected virtual Vector3 getTargetPosition()
    {
        return new Vector3(character.transform.position.x + Random.Range(-5, 5), 0, character.transform.position.y + Random.Range(-5, 5));
    }
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 targetPosition = getTargetPosition();

        result.linear = targetPosition - character.transform.position;

        // give full acceleration along this direction
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
    }
}
