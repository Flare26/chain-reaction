using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshot : MonoBehaviour
{
    public LineRenderer slingRope;
    public Transform leftPost, rightPost, ropeCenter;
    // Start is called before the first frame update
    void Start()
    {
        slingRope = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        slingRope.SetPositions(new Vector3[3] { leftPost.position, ropeCenter.position, rightPost.position });
    }
}
