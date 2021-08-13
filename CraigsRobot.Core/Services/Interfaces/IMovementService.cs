using CraigsRobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraigsRobot.Core.Services.Interfaces
{
    public interface IMovementService
    {
        void Move(ControllerDirectionEnum direction);
    }
}
