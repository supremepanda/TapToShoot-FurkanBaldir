using UnityEngine;

namespace ShootableSurfaces
{
    public class ColoredCube : ShootableSurface
    {
        protected override void Awake()
        {
            base.Awake();
            SurfaceMaterial = GetComponent<MeshRenderer>().material;
            ChangeColorRandom();
        }
        protected override void ChangeColorRandom()
        {
            Color randomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            SurfaceMaterial.color = randomColor;
        }
    }
}