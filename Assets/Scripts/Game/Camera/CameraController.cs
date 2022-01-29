using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Tilemap tilemap;
    private Vector3 _bottomLeftLimit;
    private Vector3 _topRightLimit;

    // Start is called before the first frame update
    void Start()
    {
        _bottomLeftLimit = tilemap.localBounds.min;
        _topRightLimit = tilemap.localBounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x), Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y), transform.position.z);
        }
        
    }
}
