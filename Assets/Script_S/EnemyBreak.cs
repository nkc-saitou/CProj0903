using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelImporter
{
    public class EnemyBreak : MonoBehaviour
    {
        float lifeTime = 1f;

        bool isExplositon = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(isExplositon)Explosion();
        }

        void OnTriggerEnter(Collider col)
        {
            if(col.tag == "test")
            {
                isExplositon = true;
            }
        }

        void Explosion()
        {
            var colliders = Physics.OverlapSphere(transform.position, 1f);
            for (int i = 0; i < colliders.Length; i++)
            {
                var skinnedVoxelExplosion = colliders[i].GetComponent<VoxelSkinnedAnimationObjectExplosion>();

                var voxelExplosion = colliders[i].GetComponent<VoxelBaseExplosion>();
                if (voxelExplosion == null) continue;

                if (!voxelExplosion.enabled)
                {
                    var rigidbody = colliders[i].GetComponent<Rigidbody>();
                    var rigidbodyEnabled = false;
                    if (rigidbody != null)
                    {
                        rigidbodyEnabled = rigidbody.isKinematic;
                        rigidbody.isKinematic = true;
                    }
                    var collider = colliders[i];
                    collider.enabled = false;

                    voxelExplosion.SetExplosionCenter(voxelExplosion.transform.worldToLocalMatrix.MultiplyPoint3x4(transform.position));

                    voxelExplosion.ExplosionPlay(lifeTime, () => Destroy(voxelExplosion.gameObject));
                }
            }
        }
    }
}