using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocitySlider : MonoBehaviour
{
    public Animator playerAnimator;
    public Slider velocitySlider;
    public Toggle enableAnimation;

    // Start is called before the first frame update
    void Start()
    {
        velocitySlider.value = playerAnimator.GetFloat("Velocity");
        enableAnimation.isOn = playerAnimator.GetBool("AnimationEnabled");

        velocitySlider.onValueChanged.AddListener(UpdateVelocity);
        enableAnimation.onValueChanged.AddListener(UpdateEnabled);
    }

    public void UpdateEnabled(bool param)
    {
        playerAnimator.SetBool("AnimationEnabled", param);
    }

    public void UpdateVelocity(float param) {
        playerAnimator.SetFloat("Velocity", velocitySlider.value);
    }

}
