using System.Collections;
using UnityEngine;

namespace Assets.LearnMaterials_2.Scripts
{
    public class DeleteChildScript : SampleScript
    {
        /*public DeleteChildScript(Transform tar) 
        {
            this.target = tar;
        }*/

        private Transform target;
        public override void Use()
        {
            for (int i = 0; i < target.childCount; i++)
            {
                StartCoroutine(DelandScale(target.GetChild(i).gameObject));
            }

        }
        private IEnumerator DelandScale(GameObject o)
        {
            float duration = 1f; 
            float t = 0f;
            Vector3 scale = o.transform.localScale; 
            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                o.transform.localScale = Vector3.Lerp(scale, Vector3.zero, t);
                yield return null;
            }
            Destroy(o); 
        }

    }
}