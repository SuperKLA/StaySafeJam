using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public        Rigidbody         OwnRigidbody;
    public        Animator          OwnAnimator;
    public        DraggableRecevoir KnifeDragable;
    public static Knife             Current;

    public                  GameObject KnifeLines;
    public                  bool       IsHoldingKnife;
    public                  float      DistanceThreshold = 3;
    private static readonly int        Cut               = Animator.StringToHash("Cut");
    private                 bool       NeedLines;

    private void Start()
    {
        Current = this;

        this.KnifeDragable.OnDragEnabled += this.KnifeDragableOnDragEnabled;
        this.KnifeDragable.OnDragEnd     += this.KnifeDragableOnDragEnd;
        this.OwnAnimator.enabled         =  false;
    }

    private void KnifeDragableOnDragEnd()
    {
        this.KnifeDragable.MaxMoveBounds = null;
        this.NeedLines                   = false;

        this.KnifeLines.SetActive(false);
        this.OwnRigidbody.velocity         = Vector3.zero;
        this.IsHoldingKnife                = false;
        this.OwnRigidbody.detectCollisions = true;
        this.OwnRigidbody.useGravity       = true;
    }

    private void KnifeDragableOnDragEnabled()
    {
        this.KnifeDragable.MaxMoveBounds = CuttingBoard.Current.OwnCollider.bounds;
        this.NeedLines                   = true;

        this.OwnRigidbody.angularVelocity  = Vector3.zero;
        this.OwnRigidbody.velocity         = Vector3.zero;
        this.OwnRigidbody.detectCollisions = false;
        this.OwnRigidbody.useGravity       = false;

        this.IsHoldingKnife = true;

        this.StopAllCoroutines();
        StartCoroutine(this.TurnCorrect());
    }

    IEnumerator TurnCorrect()
    {
        var rotStart  = this.transform.rotation;
        var targetRot = Quaternion.Euler(90, 0, 90);
        var wait      = new WaitForEndOfFrame();
        var _t        = 0f;

        while (_t < 1f)
        {
            yield return wait;

            _t += Time.deltaTime * 4;
            var rot = Quaternion.Lerp(rotStart, targetRot, _t);

            this.transform.rotation = rot;
        }

        this.KnifeLines.SetActive(this.NeedLines);
    }

    IEnumerator CutAnimation()
    {
        var pos          = this.transform.position;
        var a            = new AnimationCurve(new Keyframe(0, pos.y), new Keyframe(.5f, 0), new Keyframe(1, pos.y));
        var wait         = new WaitForEndOfFrame();
        var _t           = 0f;
        var hasCalledCut = false;

        while (_t < 1f)
        {
            yield return wait;

            _t += Time.deltaTime * 4;
            var value = a.Evaluate(_t);

            if (_t > 0.5f && !hasCalledCut)
            {
                hasCalledCut = true;
                this.OnKnifeIsCutting();
            }

            this.transform.position = new Vector3(pos.x, value, pos.z);
        }
    }

    public void Update()
    {
        if (!this.IsHoldingKnife) return;


        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1))
        {
            Debug.Log("Macht jetzt ein schnitt");

            // this.OwnAnimator.enabled = true;
            // OwnAnimator.SetTrigger(Cut);
            StartCoroutine(this.CutAnimation());
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

    public void OnKnifeCutEnd()
    {
        this.OwnAnimator.enabled = false;
    }

    public void OnKnifeIsCutting()
    {
        //Sound spielen
        var position = Draggable.Current.CurrentDragPosition;
        var normal   = -this.transform.up;

        var toSlice  = GameObject.FindGameObjectsWithTag("Sliceable");
        var cutItems = new List<GameObject>();

        for (int c = 0; c < toSlice.Length; c++)
        {
            var sliceable     = toSlice[c];
            var slicePosition = sliceable.transform.position;
            var knifePos      = this.transform.position;

            slicePosition.y = knifePos.y = 0;

            var dis = Vector3.Distance(slicePosition, knifePos);
            if (dis < this.DistanceThreshold)
            {
                cutItems.Add(sliceable);
            }
        }


        Cutter.Current.Cut(position, normal, cutItems.ToArray());
    }

    private void RotateKnife(int dir)
    {
        var rot   = this.transform.rotation;
        var euler = rot.eulerAngles;

        rot = Quaternion.Euler(euler + new Vector3(0, 2 * dir, 0));

        this.transform.rotation = rot;
    }
}