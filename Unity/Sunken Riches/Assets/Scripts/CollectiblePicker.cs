using UnityEngine;

public class CollectiblePicker : MonoBehaviour
{
    Camera cam;

    public double maxDistance = 5;

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
            else if (hitInfo.distance > maxDistance)
            {
                Debug.Log("Object out of reach");
            }
            else
            {
                GameObject hitObj = hitInfo.collider.gameObject;
                bool isCollectible = true;

                Debug.Log(hitObj.name);

                if (hitObj.tag.Contains("CollectibleRare"))
                {
                    ScoreTracker.Instance.rareCollected++;
                }
                else if (hitObj.tag.Contains("CollectibleCommon"))
                {
                    ScoreTracker.Instance.commonCollected++;
                }
                else if (hitObj.tag.Contains("CollectibleTrash"))
                {
                    ScoreTracker.Instance.trashCollected++;
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
