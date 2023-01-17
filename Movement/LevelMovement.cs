using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCVRClient.Movement
{
    public static class LevelMovement
    {
        public enum MovementType
        {
            preparation = 0,
            login = 1,
            init = 2,
            headquaters = 3,
            game = -1
        }

        /// <summary>
        /// OnUpdate level logic controller
        /// </summary>
        public static void SetLevel(MovementType movement, int buildIndex)
        {
            switch (buildIndex)
            {
                case 0:
                    movement = LevelMovement.MovementType.preparation;
                    break;
                case 1:
                    movement = LevelMovement.MovementType.login;
                    break;
                case 2:
                    movement = LevelMovement.MovementType.init;
                    break;
                case 3:
                    movement = LevelMovement.MovementType.headquaters;
                    break;
                case -1:
                    movement = LevelMovement.MovementType.game;
                    break;
            }
        }
    }
}
