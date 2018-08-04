using System.Collections;
using UnityEngine;

namespace Util {

    public static class Prefab {

        public static GameObject instantiate (GameObject obj, int x, int y) {
            Transform tran = GameObject.Find ("Canvas").transform;
            Vector3 position = tran.position;
            position.x += x;
            position.y += y;
            Quaternion q = new Quaternion ();
            q = Quaternion.identity;
            GameObject Instantiate = Object.Instantiate (obj, position, q) as GameObject;
            Instantiate.transform.SetParent (tran);
            return Instantiate;
        }
    }
}