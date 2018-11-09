using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TheButton : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Animator animator;

    private float whenButtonIsPressed;
    private bool isPressing = false;

    void Start()
    {
        if (!animator) animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (isPressing)
        {
            float time = Time.timeSinceLevelLoad - whenButtonIsPressed;
            slider.value = time;
        }
        else
        {
            slider.value = Mathf.Lerp(slider.value, 0, 0.5f);
        }
    }

    public void OnButtonHold()
    {

    }

    public void OnButtonDown()
    {
        whenButtonIsPressed = Time.timeSinceLevelLoad;
        isPressing = true;
        animator.SetBool("isPressing", isPressing);
    }

    public void OnButtonEnd()
    {
        isPressing = false;
        animator.SetBool("isPressing", isPressing);
    }
}
