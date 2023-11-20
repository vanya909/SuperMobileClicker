using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab = null;
    public InteractiveBox buffer = null;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject gameObject = hit.transform.gameObject;

                if (hit.collider.tag == "InteractivePlane")
                {
                    Instantiate(prefab, hit.point + hit.normal, Quaternion.identity);
                }
                else if (gameObject.GetComponent<InteractiveBox>() != null)
                {
                    InteractiveBox nextbox = gameObject.GetComponent<InteractiveBox>();
                    if (buffer != null)
                    {
                        nextbox.AddNext(buffer);

                        buffer = null;
                    }
                    else
                    {
                        buffer = gameObject.GetComponent<InteractiveBox>();

                    }
                }
            }
        }
        else if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.GetComponent("InteractiveBox") != null)
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}

