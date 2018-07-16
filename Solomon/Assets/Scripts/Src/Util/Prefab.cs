using System.Collections;
using UnityEngine;

namespace Util {

    public static class Prefab {

        public static GameObject instantiate (GameObject obj, int x, int y) {
            Vector3 position = GameObject.Find ("Canvas").transform.position;
            position.x += x;
            position.y += y;
            Quaternion q = new Quaternion ();
            q = Quaternion.identity;
            return Object.Instantiate (obj, position, q) as GameObject;
        }
    }
}