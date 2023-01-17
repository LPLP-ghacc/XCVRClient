using RTG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XCVRClient.System;

namespace XCVRClient.Movement
{
    public static class TeleportTo
    {
        public static void OnUpdate()
        {
            var rayend = new Vector3(0, 0, 0);

            Vector3 Rayposition = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Rayposition); 
                
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    InstanceProfiler.player.movementSystem.TeleportTo(hit.point);
                }
                else return;       
            }
        }
    }
}
