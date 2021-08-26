using UnityEngine;

[ExecuteInEditMode]
public class HeroBendController : MonoBehaviour
{
    private static readonly int PLAYERWORLDPOS_ID = Shader.PropertyToID("_PLAYERWORLDPOS");
    private static readonly int HORIZON_ID = Shader.PropertyToID("_HORIZON");
    private static readonly int SPREAD_ID = Shader.PropertyToID("_SPREAD");
    private static readonly int ATTENUATE_ID = Shader.PropertyToID("_ATTENUATE");
    private static readonly int CURVATURE_ID = Shader.PropertyToID("_CURVATURE");

    [SerializeField] protected float attenuate = 1.0f;
    [SerializeField] protected float horizonOffset = 0.0f;
    [SerializeField] protected float spread = 1.0f;
    [SerializeField] protected float curvature = 0.01f;
    [SerializeField] protected Transform player;

    protected void OnEnable()
    {
        Shader.EnableKeyword("BEND_ON");
    }

    protected void Update()
    {
        if (!player) enabled = false;
        Shader.SetGlobalVector(PLAYERWORLDPOS_ID, player.position);
        Shader.SetGlobalFloat(CURVATURE_ID, curvature);
        Shader.SetGlobalFloat(HORIZON_ID, player.position.z + horizonOffset);
        Shader.SetGlobalFloat(SPREAD_ID, spread);
        Shader.SetGlobalFloat(ATTENUATE_ID, attenuate);
    }

    protected void OnDisable()
    {
        Shader.DisableKeyword("BEND_ON");
        Shader.SetGlobalFloat(ATTENUATE_ID, 0);
        Shader.SetGlobalFloat(SPREAD_ID, 0);
        Shader.SetGlobalFloat(HORIZON_ID, 0);
        Shader.SetGlobalFloat(CURVATURE_ID, 0);
    }
}
