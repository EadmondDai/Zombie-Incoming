using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impackCanvas;
    [SerializeField] float impactTime = 0.3f;
    bool canShow = true;

    // Start is called before the first frame update
    void Start()
    {
        impackCanvas.enabled = false;   
    }

    public void OnImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        if (canShow)
        {
            canShow = false;
            impackCanvas.enabled = true;
            yield return new WaitForSeconds(impactTime);
            impackCanvas.enabled = false;
            canShow = true;
        }

    }
}
