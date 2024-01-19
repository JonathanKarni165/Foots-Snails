using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVariable : MonoBehaviour
{
    public string varName, value;

    public UIVariable(string varName, string value)
    {
        this.value = value;
        this.varName = varName;
    }
}
