using UnityEngine;

public class MeshColliderUpdate : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    MeshCollider meshCollider;
    private Mesh mesh;
    private float time = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.25f)
        {
            time = 0;
            UpdateCollider();
        }
    }
    
    
    public void UpdateCollider()
    {
        meshCollider.sharedMesh = null;
        
        mesh = new Mesh();

        
        
        
        //mesh.Optimize();
        //mesh.RecalculateNormals();
        
        meshRenderer.BakeMesh(mesh);
        meshCollider.sharedMesh = mesh;
    }
}