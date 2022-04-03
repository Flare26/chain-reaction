using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshotSling : MonoBehaviour
{
    public LineRenderer slingRope;
    public Transform leftPost, rightPost, crateHolder;
    // Start is called before the first frame update
    void Start()
    {
        slingRope = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        slingRope.SetPositions(new Vector3[3] { leftPost.position, crateHolder.position, rightPost.position });
    }
}
