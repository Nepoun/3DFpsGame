using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDefaultBehavior : MonoBehaviour
{
    #region Variables

    private Vector3 defaultScale;
    public GameObject debugSizeObject;
    #endregion

    #region MonoBehavior Callbacks

    void Start()
    {
        defaultScale = debugSizeObject.transform.lossyScale;
    }
    void Update()
    {
        SetGlobalScale(debugSizeObject.transform, defaultScale);
    }

    #endregion

    #region Private Methods
    void SetGlobalScale(Transform transform, Vector3 globalScale)
    {
        transform.localScale = Vector3.one;
        transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
    }
    #endregion
}