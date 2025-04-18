using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrePareUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    private Action onComplete;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    public void Show(Action onComplete)
    {
        this.onComplete = onComplete;
        anim.enabled = true;   
    }
    void OnShowComplete()
    {
        onComplete?.Invoke();
    }
}
