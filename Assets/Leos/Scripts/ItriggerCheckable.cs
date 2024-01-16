using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItriggerCheckable 
{
    bool IsWithinStrikingDistance { get; set; }

    void SetStrikingDistanceBool(bool isWithinStrikingDistance);
}
