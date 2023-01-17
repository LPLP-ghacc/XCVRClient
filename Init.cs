using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCVRClient;
using MelonLoader;
using XCVRClient.System;
using UnityEngine;
using XCVRClient.Movement;
using System.Net.Http.Headers;
using ABI_RC.Core.Player;
using XCVRClient.Interface;

namespace XCVRClient
{
    public class Init : MelonMod
    {
        public LevelMovement.MovementType thisLevel { get; set; }

        public InstanceProfiler.EInstance instanceState { get; set; }

        private int level { get; set; }

        [Obsolete]
        public override void OnApplicationStart()
        {
            
        }

        public override void OnApplicationQuit()
        {
            
        }

        public override void OnUpdate()
        {
            if(level == ((int)LevelMovement.MovementType.game))
            {
                if (instanceState == InstanceProfiler.EInstance.online)
                {
                    //online instance
                    Trajectories.OnUpdate();
                }

                //offline/online instance
                TeleportTo.OnUpdate();
            }  
        }

        /// <summary>
        /// Scene was fully loaded
        /// </summary>
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LevelMovement.SetLevel(thisLevel, buildIndex); level = buildIndex;

            if (buildIndex == ((int)LevelMovement.MovementType.game))
            {
                InstanceProfiler.OnStart();

                if(InstanceProfiler.isInstanceOnline()) 
                    instanceState = InstanceProfiler.EInstance.online;
                else 
                    instanceState = InstanceProfiler.EInstance.offline;
            } 
        }
    }
}
