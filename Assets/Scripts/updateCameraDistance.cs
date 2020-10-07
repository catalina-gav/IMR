using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class updateCameraDistance : MonoBehaviour
{
    Animator animator;
    private float cameraDist;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float cameraX = Camera.main.transform.position.x;
        float cameraY = Camera.main.transform.position.y;
        float x = transform.position.x;
        float y = transform.position.y;

        cameraDist = Mathf.Sqrt((cameraX - x)*(cameraX - x) + (cameraY - y) * (cameraY - y));
        Debug.Log(cameraDist);

        animator.SetFloat("cameraDistance", cameraDist);
    }
}
