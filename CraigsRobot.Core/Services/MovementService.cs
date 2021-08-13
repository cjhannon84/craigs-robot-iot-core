using CraigsRobot.Core.Models;
using CraigsRobot.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace CraigsRobot.Core.Services
{
    public class MovementService : IMovementService
    {
        private const short GpioPinForModulePin1 = 24;
        private const short GpioPinForModulePin2 = 23;
        private const short GpioPinForModulePin3 = 27;
        private const short GpioPinForModulePin4 = 17;

        private GpioController _gpioController;

        public MovementService()
        {
            Init();
        }

        public void Move(ControllerDirectionEnum directionOfRobot)
        {
            switch (directionOfRobot)
            {
                case ControllerDirectionEnum.Forwards:
                    MoveForwards();
                    break;
                case ControllerDirectionEnum.Reverse:
                    MoveBackwards();
                    break;
                case ControllerDirectionEnum.Left:
                    MoveLeft();
                    break;
                case ControllerDirectionEnum.Right:
                    MoveRight();
                    break;
                default:
                    Neutral();
                    break;
            }
        }

        private GpioPin modulePin1;
        private GpioPin modulePin2;
        private GpioPin modulePin3;
        private GpioPin modulePin4;

        private void Init()
        {
            _gpioController = GpioController.GetDefault();
            modulePin1 = _gpioController.OpenPin(GpioPinForModulePin1,GpioSharingMode.Exclusive);
            modulePin2 = _gpioController.OpenPin(GpioPinForModulePin2, GpioSharingMode.Exclusive);
            modulePin3 = _gpioController.OpenPin(GpioPinForModulePin3, GpioSharingMode.Exclusive);
            modulePin4 = _gpioController.OpenPin(GpioPinForModulePin4, GpioSharingMode.Exclusive);

            modulePin1.SetDriveMode(GpioPinDriveMode.Output);
            modulePin2.SetDriveMode(GpioPinDriveMode.Output);
            modulePin3.SetDriveMode(GpioPinDriveMode.Output);
            modulePin4.SetDriveMode(GpioPinDriveMode.Output);
        }

        private void MoveForwards()
        {
            ConfigureMotorModule(false, true, false, true);
        }

        private void MoveBackwards()
        {
            ConfigureMotorModule(true, false, true, false);
        }

        private void MoveLeft()
        {
            ConfigureMotorModule(false, true, true, false);
        }

        private void MoveRight()
        {
            ConfigureMotorModule(true, false, false, true);
        }

        private void Neutral()
        {
            ConfigureMotorModule(false, false, false, false);
        }

        private void ConfigureMotorModule(bool pinOneOn, bool pinTwoOn, bool pinThreeOn, bool pinFourOn)
        {

            modulePin1.Write(pinOneOn ? GpioPinValue.High : GpioPinValue.Low);
            modulePin2.Write(pinTwoOn ? GpioPinValue.High : GpioPinValue.Low);
            modulePin3.Write(pinThreeOn ? GpioPinValue.High : GpioPinValue.Low);
            modulePin4.Write(pinFourOn ? GpioPinValue.High : GpioPinValue.Low);
        }
    }
}
