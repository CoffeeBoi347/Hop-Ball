using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject targetObj;
    private GameObject tileObj;
    public Vector3 mousePosition;
    public float jumpPower;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        AccessClosestObject();
        InputControls();
    }

    public void AccessClosestObject()
    {
        List<GameObject> fullTilesData = TileManager._instance.tilesBeingSpawned;
        int tilesCount = TileManager._instance.itemsSpawned;
        float closestDistance = Mathf.Infinity;

        foreach (var tile in fullTilesData)
        {
            if (fullTilesData.Count == 0)
            {
                Debug.Log("ADDING ITEMS! PLEASE WAIT");
                break;
            }

            float distance = tile.transform.position.z - transform.position.z;

            if (distance > 0f && distance < closestDistance && targetObj != null)
            {
                closestDistance = distance;
                targetObj = tile;
            }
        }

        if (targetObj != null)
        {
            tileObj = targetObj;
        }
        else
        {
            Debug.Log("No valid target found ahead.");
        }

    }

    public void InputControls()
    {
        mousePosition = Input.mousePosition;
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //    transform.position = new Vector3(worldPosition.x, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(0f, jumpPower, 0f);
        }
    }
}