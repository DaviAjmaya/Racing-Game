using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPart
{

    public Dictionary<string, bool> validParts = new Dictionary<string, bool>();
    public string part = "empty";

    public TrackPart()
    {
        validParts["leftUp"] = true;
        validParts["leftDown"] = true;
        validParts["rightUp"] = true;
        validParts["rightDown"] = true;
        validParts["straightZ"] = true;
        validParts["straightX"] = true;
        validParts["start"] = true;
        validParts["end"] = true;
        validParts["empty"] = false;
        part = "empty";
    }
    public int getNumOfValidParts()
    {
        int num = 0;

        foreach (var item in validParts.Values)
        {
            if (item == true)
                num++;
        }

        return num-2;
    }
}
