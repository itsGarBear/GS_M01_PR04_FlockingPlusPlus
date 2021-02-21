using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering
{
    float epsilon = 0.1f;

    public BlendedSteering[] myGroups;

    public SteeringOutput getSteering()
    {
        SteeringOutput steering = new SteeringOutput();
        foreach (BlendedSteering group in myGroups)
        {
            steering = group.getSteering();
            if (steering.linear.magnitude > epsilon || Mathf.Abs(steering.angular) > epsilon)
                return steering;
        }
        return steering;
    }
}
