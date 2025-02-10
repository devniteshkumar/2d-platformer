using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Start is called before the first frame update
    Vector2 startPosition;
    float StartZPos;
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startPosition;
    float zdistanceFromTarget => transform.position.z - followTarget.position.z;
    float ClippingPlane => (cam.transform.position.z + (zdistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zdistanceFromTarget / ClippingPlane);

    void Start()
    {
        startPosition = transform.position;
        StartZPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startPosition + camMoveSinceStart * parallaxFactor;  
        transform.position = new Vector3(newPosition.x, newPosition.y, StartZPos);
    }
}
