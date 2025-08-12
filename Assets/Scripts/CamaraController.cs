using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class CamaraController : MonoBehaviour
{

    public static CamaraController instance;

    public Transform target;
    public Tilemap theMap;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerControl>().transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;    // whatever is set in the game window 16:9//

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth,halfHeight, 0);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0);

        PlayerControl.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Keep the cam inside the bounds yo //
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
