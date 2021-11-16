﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSlider : MonoBehaviour
{
    public Slider slider;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnValueChanged()
    {
        animator.Play("monsterslide", -1, slider.normalizedValue);
    }
}
