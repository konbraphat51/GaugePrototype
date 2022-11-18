using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Must to call Initialize() first
/// </summary>
public class Gauge : MonoBehaviour
{
    //where Fill comes until
    private float showingRatio = 0f;

    private float excellentWidthRatio = 0.1f;
    private float excellentCenterRatio = 0.5f;

    [SerializeField] private GameObject rightEdgeObject;
    private float rightEdge;
    [SerializeField] private GameObject leftEdgeObject;
    private float leftEdge;

    [SerializeField] private GameObject reachedMovingMask;
    [SerializeField] private GameObject excellentRectMask;

    [Tooltip("Reverse")]
    [SerializeField] public bool goingRight;

    private void Start()
    {
        //set edge variable
        GetEdge();
    }

    /// <summary>
    /// this must be called
    /// </summary>
    /// <param name="showingRatio"></param>
    /// <param name="excellentWidthRatio"></param>
    /// <param name="excellentCenterRatio"></param>
    public void Initialize(float showingRatio,
        float excellentWidthRatio,
        float excellentCenterRatio)
    {
        //initialize variable
        this.showingRatio = showingRatio;

        //in case if this come earlier than Start()
        GetEdge();

        //Move to start point
        Animate();

        //edit excellent zone rect
        SetExcellentAreaRect(excellentWidthRatio, excellentCenterRatio);
    }

    /// <summary>
    /// Displaying gauge changes by here. 
    /// </summary>
    /// <param name="ratio"></param>
    public void SetRatio(float ratio)
    {
        showingRatio = ratio;

        //guard
        if (showingRatio < 0f) showingRatio = 0f;
        if (showingRatio > 1f) showingRatio = 1f;

        Animate();
    }

    //reached sprite move by here.
    private void Animate()
    {
        //where the mask position go
        float edgePosX = GetHorizontalPosition(showingRatio);

        //move the mask
        reachedMovingMask.transform.position = new Vector2(edgePosX, reachedMovingMask.transform.position.y);
    }

    private void GetEdge()
    {
        rightEdge = rightEdgeObject.transform.position.x;
        leftEdge = leftEdgeObject.transform.position.x;
    }

    private void SetExcellentAreaRect(float widthRatio, float centerRatio)
    {
        float centerPosX = GetHorizontalPosition(centerRatio);

        excellentRectMask.transform.localScale = new Vector2(widthRatio, excellentRectMask.transform.localScale.y);
        excellentRectMask.transform.position = new Vector2(centerPosX, excellentRectMask.transform.position.y);
    }

    private float GetHorizontalPosition(float ratio)
    {
        float output = 0f;

        switch (goingRight)
        {
            case false:
                //going left
                output = rightEdge - (rightEdge - leftEdge) * ratio;
                break;
            case true:
                //going right
                output = leftEdge + (rightEdge - leftEdge) * ratio;
                break;
        }

        return output;
    }
}
