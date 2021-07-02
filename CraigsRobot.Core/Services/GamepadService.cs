using CraigsRobot.Core.Helpers;
using CraigsRobot.Core.Models;
using System.Linq;
using Windows.Gaming.Input;

namespace CraigsRobot.Core.Services
{
    public class GamepadService : IGamepadService
    {
        public ControllerDirectionEnum GetCurrentReading()
        {
            var gamepad = Gamepad.Gamepads.FirstOrDefault();

            if (gamepad == null)
                return ControllerDirectionEnum.Neutral;

            var currentGamepadReading = gamepad.GetCurrentReading();

            return ControllerDirectionHelpers.GetControllerDirection(currentGamepadReading.LeftThumbstickX, currentGamepadReading.LeftThumbstickY);
        }
    }
}
