using UnityEngine;
using UnityEngineInternal;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab = null;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)){
                var gameObject = hit.transform.gameObject;

                if (hit.collider.tag == "InteractivePlane") {
                    Instantiate(prefab, hit.point + hit.normal, Quaternion.identity);
                } else if (gameObject.GetComponent("InteracriveBox") != null) {
                    if (prefab != null) {
                        InteractiveBox prefabInteractiveBox = (InteractiveBox)prefab.GetComponent("InteractiveBox");
                        ((InteractiveBox)gameObject.GetComponent("InteracriveBox")).AddNext(prefabInteractiveBox);
                        prefab = null;
                    } else {
                        prefab = gameObject;
                    }
                }
            }
        } else if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}

