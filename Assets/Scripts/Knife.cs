using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Animator OwnAnimator;
    public Dragable KnifeDragable;
    public static Knife Current;
    
    public bool IsHoldingKnife;
    private static readonly int Cut = Animator.StringToHash("Cut");

    private void Start()
    {
        Current = this;
        
        this.KnifeDragable.OnDragEnabled += this.KnifeDragableOnDragEnabled;
        this.KnifeDragable.OnDragEnd += this.KnifeDragableOnDragEnd;
    }

    private void KnifeDragableOnDragEnd()
    {
        this.IsHoldingKnife = false;
    }

    private void KnifeDragableOnDragEnabled()
    {
        this.IsHoldingKnife = true;
    }

    public void Update()
    {
        if (!this.IsHoldingKnife) return;
        
        
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1))
        {
            Debug.Log("Macht jetzt ein schnitt");

            OwnAnimator.SetTrigger(Cut);
            // var position = this.KnifeDragable.CurrentDragPosition;
            // var normal = this.transform.right;
            //
            // var toSlice = GameObject.FindGameObjectsWithTag("Sliceable");
            // Cutter.Current.Cut(position, normal, toSlice);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            this.RotateKnife(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.RotateKnife(1);
        }
    }

    public void OnKnifeIsCutting()
    {
        //Sound spielen
        var position = this.KnifeDragable.CurrentDragPosition;
        var normal   = this.transform.right;

        var toSlice = GameObject.FindGameObjectsWithTag("Sliceable");
        Cutter.Current.Cut(position, normal, toSlice);
    }

    private void RotateKnife(int dir)
    {
        var rot = this.transform.rotation;
        var euler = rot.eulerAngles;
        
        rot = Quaternion.Euler(euler + new Vector3(0, 2 * dir, 0));

        this.transform.rotation = rot;
    }
}