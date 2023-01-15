using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundry
{
    public class DuplicationTool : MonoBehaviour
    {
        public GameObject objectToDuplicate;
        public int numberOfClusters;
        public float clusterRadius;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < numberOfClusters; i++) {
                Vector3 randomPos = Random.insideUnitSphere * clusterRadius;
                Instantiate(objectToDuplicate, transform.position + randomPos, Quaternion.identity);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
