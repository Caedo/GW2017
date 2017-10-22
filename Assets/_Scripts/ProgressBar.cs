using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public Transform progressBar1;
    public Transform progressBar2;
    public Transform tower1;
    public Transform tower2;

    private float currentAmount1;
    private float currentAmount2;

    // Use this for initialization
    void Start()
    {
        tower1 = GameManager.Instance.m_Towers[0].transform;
        tower2 = GameManager.Instance.m_Towers[1].transform;

    }

    // Update is called once per frame
    void Update()
    {
        Progress(progressBar1, tower1);
        Progress(progressBar2, tower2);
    }

    void Progress(Transform progressBar, Transform tower)
    {
        var blocks = tower.GetComponentsInChildren<Block>();
        float minHeight = 1000.0f;
        float maxHeight = 0.0f;

        for(int i = 0; i < blocks.Length; i++)
        {
            float blockHeight = blocks[i].transform.position.y;
            if(blockHeight > maxHeight)
            {
                maxHeight = blockHeight;
            }
            if(blockHeight < minHeight)
            {
                minHeight = blockHeight;
            }
        }

        progressBar.GetComponent<Image>().fillAmount = (maxHeight - minHeight)/10;
    }
}
