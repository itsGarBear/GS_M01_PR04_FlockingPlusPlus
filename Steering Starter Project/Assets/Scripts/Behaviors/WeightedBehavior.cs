using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedBehavior
{
    public SteeringBehavior behavior = null;
    public float weight = 0f;
}

public class BlendedSteering
{
    public WeightedBehavior[] behaviors;

    float maxAcceleration = 2f;
    float maxRotation = 10f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        foreach(WeightedBehavior b in behaviors)
        {
            SteeringOutput so = b.behavior.getSteering();
            if(so != null)
            {
                result.linear += so.linear * b.weight;
                result.angular += so.angular * b.weight;
            }
        }

        result.linear = result.linear.normalized * maxAcceleration;
        float angularAcc = Mathf.Abs(result.angular);
        if(angularAcc > maxRotation)
        {
            result.angular /= angularAcc;
            result.angular *= maxRotation;
        }

        return result;
    }
}
