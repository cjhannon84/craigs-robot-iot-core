using CraigsRobot.Core.Models;

namespace CraigsRobot.Core.Services
{
    public interface IGamepadService
    {
        ControllerDirectionEnum GetCurrentReading();
    }
}
