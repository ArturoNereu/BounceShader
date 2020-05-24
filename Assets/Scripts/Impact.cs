using UnityEngine;

public class Impact : MonoBehaviour
{
    private Camera m_MainCamera;

    private Material m_Material;

    private int m_RaycastHitHash;
    private int m_ImpactValueAtCurveHash;

    private float m_TimeSincePressed;

    public AnimationCurve m_AnimationCurve;


    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_Material = GetComponent<Renderer>().material;
        m_RaycastHitHash = Shader.PropertyToID("Vector3_B0DDBEEE");
        m_ImpactValueAtCurveHash = Shader.PropertyToID("Vector1_E44E3D54");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_TimeSincePressed = 0;

            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            
            if(Physics.Raycast(ray, out raycastHit))
            {
                m_Material.SetVector(m_RaycastHitHash, raycastHit.transform.position);
            }
            else
            {
                // TODO: Remove 
                m_Material.SetVector(m_RaycastHitHash, new Vector4(1000,1000,1000,100)) ;
            }
        }

        m_TimeSincePressed += Time.deltaTime;
        m_Material.SetFloat(m_ImpactValueAtCurveHash, EvaluateCurve(m_TimeSincePressed));
    }

    float EvaluateCurve(float time)
    {
        return m_AnimationCurve.Evaluate(time);
    }
}
