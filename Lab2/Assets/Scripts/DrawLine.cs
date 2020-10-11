using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DrawLine : MonoBehaviour
{
    public VRTK_InteractableObject linkedObject;
    public GameObject linePrefab;
    private GameObject line;
    private LineRenderer lineRenderer;

    bool drawing;

    private void Start()
    {
        drawing = false;
        linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            linkedObject.InteractableObjectUnused += InteractableObjectUnused;
        }


    }

    void Update()
    {
        //if (Input.GetButtonDown())
        Draw();

    }

    private void Draw()
    {
        if (drawing)
        {
            if (Vector3.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), transform.position) > 0.1f)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
            }
        }
    }

    private void CreateLine()
    {
        line = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        Debug.Log("am instantiat new line");
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        CreateLine();
        drawing = true;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
        drawing = false;
        
    }
}
