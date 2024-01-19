using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowVar : MonoBehaviour
{
    public TextMeshProUGUI tm;
    public string reference;
    UIVariable myVar;

    private void Start()
    {
        myVar = null;

        UIVariable[] vars = FindObjectsOfType<UIVariable>();
        foreach(UIVariable var in vars)
        {
            if (var.varName == reference)
                myVar = var;
        }
    }

    private void Update()
    {
        if(myVar != null)
            tm.text = myVar.varName + " : " + myVar.value;
    }
}
