using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyDropManager : MonoBehaviour
{
    [SerializeField] GameObject healthDropHeightMark;
    [SerializeField] float minDistanceToMark;
    [SerializeField] float maxDistanceToMark;
    [SerializeField] float dropInterval;

    private int currentDropIdx = 1;

    [SerializeField] GameObject healthDrop;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TryToDropSupply());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TryToDropSupply()
    {
        yield return new WaitForSeconds(dropInterval * currentDropIdx);
        currentDropIdx++;

        if (healthDrop != null)
        {

            float radiant = Random.Range(0f, 2 * Mathf.PI);
            float distance = Random.Range(minDistanceToMark, maxDistanceToMark);

            Vector3 dropLocation = new Vector3(
                distance * Mathf.Cos(radiant),
                healthDropHeightMark.transform.position.y,
                distance * Mathf.Sin(radiant)
            ); 

            
        }
    }
}
