using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    private Camera cam;
    private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera")?.GetComponent<Camera>();
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null || canvas == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit = new RaycastHit();
            if (Physics.Raycast(ray, out raycastHit))
            {
                GameObject hitObject = raycastHit.collider.gameObject;
                GameObject textObject = canvas.transform.Find(hitObject.name + "Text")?.gameObject;
                if (textObject != null)
                {
                    Text text = textObject.transform.Find("Text")?.GetComponent<Text>();
                    if(text != null)
                    {
                        text.text = hitObject.name.Replace("Sphere", "");
                    }
                    textObject.SetActive(!textObject.activeSelf);
                }
            }
        }
    }
}
