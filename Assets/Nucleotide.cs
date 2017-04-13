using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nucleotide : MonoBehaviour {

    public Text label;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLabel(string newLabel)
    {
        label.text = newLabel; 
    }
}
