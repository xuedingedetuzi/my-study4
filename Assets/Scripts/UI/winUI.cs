using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winUI : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Hide();
    }
    void Hide()
    {
        anim.enabled = false;
    }
    public void Show()
    {
        anim.enabled = true;
    }
}
