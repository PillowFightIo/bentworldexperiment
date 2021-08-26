using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BenderCamera : MonoBehaviour
{
    [Range(0, 0.5f)] [SerializeField] protected float extraCullHeight;
    [SerializeField] private new Camera camera;

    protected void OnValidate()
    {
        if (!camera) camera = GetComponent<Camera>();
    }

    private void Start()
    {
        if (camera == null) enabled = false;
    }

    private void OnPreCull()
    {
        float ar = camera.aspect;
        float fov = camera.fieldOfView;
        float viewPortHeight = Mathf.Tan(Mathf.Deg2Rad * fov * 0.5f);
        float viewPortwidth = viewPortHeight * ar;

        float newfov = fov * (1 + extraCullHeight);
        float newheight = Mathf.Tan(Mathf.Deg2Rad * newfov * 0.5f);
        float newar = viewPortwidth / (newheight);

        camera.projectionMatrix = Matrix4x4.Perspective(newfov, newar, camera.nearClipPlane, camera.farClipPlane);
    }

    private void OnPreRender()
    {
        camera.ResetProjectionMatrix();
    }
}
