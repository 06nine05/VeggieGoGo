using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public class ItemSpawner : MonoBehaviour
    {
        public GameObject[] itemType;
        public Transform spawnerPos;

        private GameObject item;

        // Start is called before the first frame update
        void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            item = Instantiate(itemType[Random.Range(0, itemType.Length)], spawnerPos.position, Quaternion.identity);
        }
    }
}