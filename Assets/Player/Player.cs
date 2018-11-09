using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private TheButton button;

    [SerializeField] private float maxRaycastDistance = 20;
    [SerializeField] private KeyCode Mouse0Key = KeyCode.Mouse0;

    void Start()
    {
        if(!cam) cam = Camera.main;
        if(!button) button = FindObjectOfType<TheButton>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(Mouse0Key))
        {
            RaycastHit hit;
            Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxRaycastDistance);
            if (hit.transform)
            {
                if (hit.transform.GetComponent<TheButton>()) button.OnButtonDown();
                else { button.OnButtonEnd(); }
            }
            else { button.OnButtonEnd(); }
        }
        if (Input.GetKey(Mouse0Key))
        {
            RaycastHit hit;
            Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxRaycastDistance);
            if (hit.transform)
            {
                if (hit.transform.GetComponent<TheButton>()) button.OnButtonHold();
                else { button.OnButtonEnd(); }
            }
            else
            {
                button.OnButtonEnd();
            }
        }
        else
        {
            button.OnButtonEnd();
        }
    }
}
