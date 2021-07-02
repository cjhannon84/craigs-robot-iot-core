using CraigsRobot.Core.Models;

namespace CraigsRobot.Core.Helpers
{
    public static class ControllerDirectionHelpers
    {
        public static ControllerDirectionEnum GetControllerDirection(double xAxis, double yAxis)
        {
            if (xAxis == 1 && (yAxis > -1 && yAxis < 1))
                return ControllerDirectionEnum.Right;
            else if (xAxis == -1 && (yAxis > -1 && yAxis < 1))
                return ControllerDirectionEnum.Left;
            else if (yAxis == 1 && (xAxis > -1 && xAxis < 1))
                return ControllerDirectionEnum.Forwards;
            else if (yAxis == -1 && (xAxis > -1 && xAxis < 1))
                return ControllerDirectionEnum.Reverse;

            return ControllerDirectionEnum.Neutral;
        }
    }
}
