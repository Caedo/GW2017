using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public Transform progressBar1;
    public Transform progressBar2;

    private float currentAmount1;
    private float currentAmount2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        progressBar1.GetComponent<Image>().fillAmount = currentAmount1 / 10;
        progressBar2.GetComponent<Image>().fillAmount = currentAmount2 / 10;

    }
}
