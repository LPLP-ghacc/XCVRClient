using ABI_RC.Core.Player;
using Harmony;
using RTG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XCVRClient.System;
using Random = UnityEngine.Random;

namespace XCVRClient.Interface
{
    public static class Trajectories
    {
        public static bool isEnable = false;

        private static List<GameObject> trajectories = new List<GameObject>();

        private static List<CVRPlayerEntity> players = new List<CVRPlayerEntity>(); 

        public static void OnUpdate()
        {
            if(Input.GetKeyDown(KeyCode.T)) 
            {
                if (!isEnable)
                {
                    isEnable = !isEnable;

                    players = CVRPlayerManager.Instance.NetworkPlayers;

                    playersCount = players.Count;

                    foreach (var player in players)
                    {
                        CreateTrajector(player);
                    }

                    return;
                }
                if (isEnable)
                {
                    isEnable = !isEnable;

                    try
                    {
                        ClearAll();
                    }
                    catch { }

                    return;
                } 
            }

            if (isEnable)
            {
                try
                {
                    foreach (var player in players)
                    {
                        var otherPosition = player.PlayerObject.transform.position;

                        var playerPostion = InstanceProfiler.player.playerTransform.position;

                        var trajector = GameObject.Find(player.Username + " Trajector");

                        trajector.transform.localScale = new Vector3(0.02f, 0.01f, Vector3.Distance(playerPostion, otherPosition));

                        trajector.transform.position = Vector3.Lerp(new Vector3(playerPostion.x, playerPostion.y + 0.2f, playerPostion.z), otherPosition, 0.5f);

                        trajector.transform.LookAt(otherPosition);
                    }
                }
                catch 
                {
                    Refresh();
                }

                Refresh();
            }
        }

        private static int playersCount;

        private static bool PlayerSum()
        {
            if(playersCount != CVRPlayerManager.Instance.NetworkPlayers.Count)
                return false;
            else
                return true;
        }

        private static void CreateTrajector(CVRPlayerEntity player)
        {
            var otherPosition = player.PlayerObject.transform.position;

            var playerPostion = InstanceProfiler.player.playerTransform.position;

            var trajector = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Shader shader = Shader.Find("UI/Default");

            Material material = new Material(shader);

            material.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);

            trajector.GetComponent<Renderer>().material = material;

            trajector.GetComponent<Collider>().enabled = false;

            trajector.name = player.Username + " Trajector";

            trajector.transform.localScale = new Vector3(0.01f, 0.001f, Vector3.Distance(playerPostion, otherPosition));

            trajector.transform.position = Vector3.Lerp(playerPostion, otherPosition, 0.5f);

            trajector.transform.LookAt(otherPosition);

            trajectories.Add(trajector);
        }

        private static void ClearAll()
        {
            if(trajectories.Count > 0)
            {
                foreach (var trajector in trajectories)
                {
                    GameObject.Destroy(trajector);
                }
            }        
        }

        private static void Refresh()
        {
            if (!PlayerSum())
            {
                ClearAll();

                foreach (var player in players)
                {
                    CreateTrajector(player);
                }
            }
        }
    }
}
