using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{

    public int sequenceNum = 2;
    public List<GameObject> memoryObjects;

    public Material glowMaterial;

    private float timeBetweenGlows = .4f;
    private float glowTime = 1f;
    private List<int> objectOrder = new List<int>();
    private int orderUpto;

    private Material prevMaterial;

    private void Start()
    {
        StartSequence();
    }

    public void StartSequence()
    {
        objectOrder.Clear();
        for(int i = 0; i < sequenceNum; i++)
        {
            objectOrder.Add(Random.Range(0, memoryObjects.Count - 1));
        }
        StartCoroutine(DoMemorySequence());
    }

    IEnumerator DoMemorySequence()
    {

        yield return new WaitForSecondsRealtime(3);

        for (int i = 0; i < objectOrder.Count; i++)
        {

            //make object glow
            //wait time
            //stop glow
            //wait time
            //make next

            GameObject currentObject = memoryObjects[objectOrder[i]];
            prevMaterial = currentObject.GetComponent<Renderer>().material;
            currentObject.GetComponent<Renderer>().material = glowMaterial;

            yield return new WaitForSecondsRealtime(glowTime);

            currentObject.GetComponent<Renderer>().material = prevMaterial;

            yield return new WaitForSecondsRealtime(timeBetweenGlows);

        }

        orderUpto = 0;

        foreach (GameObject obj in memoryObjects)
        {
            obj.GetComponent<PatternObject>().StartRecording();
        }

        StopCoroutine(DoMemorySequence());
            
    }

    public void GetHit(GameObject hitPattern)
    {
        if (memoryObjects[objectOrder[orderUpto]] == hitPattern)//if right one
        {
            orderUpto++;
            if(orderUpto == objectOrder.Count)
            {
                FinishPattern();
            }
        }
        else
        {
            orderUpto = 0;
        }
    }

    public void FinishPattern()
    {
        print("puzzle complete");
        foreach (GameObject obj in memoryObjects)
        {
            obj.GetComponent<PatternObject>().StopRecording();
        }
    }



}
