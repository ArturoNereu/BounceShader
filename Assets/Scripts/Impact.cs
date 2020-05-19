using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    private Camera m_MainCamera;

    private Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            
            if(Physics.Raycast(ray, out raycastHit))
            {
                m_Material.SetVector("Vector3_B0DDBEEE", raycastHit.point);
                Debug.Log("Input: " + raycastHit.point);
            }
        }
    }
}
