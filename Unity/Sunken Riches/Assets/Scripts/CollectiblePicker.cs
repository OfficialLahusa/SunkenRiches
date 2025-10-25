using UnityEngine;

public class CollectiblePicker : MonoBehaviour
{
    Camera cam;

    public int trashCollected = 0;
    public int commonCollected = 0;
    public int rareCollected = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo);

            if (hitInfo.collider == null)
            {
                Debug.Log("No hit");
            }
            else
            {
                GameObject hitObj = hitInfo.collider.gameObject;
                bool isCollectible = true; 

                Debug.Log(hitObj.name);

                if (hitObj.tag.Contains("CollectibleRare"))
                {
                    rareCollected++;
                }
                else if (hitObj.tag.Contains("CollectibleCommon"))
                {
                    commonCollected++;
                }
                else if (hitObj.tag.Contains("CollectibleTrash"))
                {
                    trashCollected++;
                }
                else
                {
                    isCollectible = false;
                }

                if (isCollectible)
                {
                    Destroy(hitObj);
                }
            }
        }
    }
}
