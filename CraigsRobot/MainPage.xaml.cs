using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CraigsRobot.Core.Services;
using Windows.UI.Core;
using CraigsRobot.Core.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CraigsRobot
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Task readInputTask;
        private CancellationTokenSource cancelTokenSource;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task ReadInputLoop(CancellationToken token)
        {
            var gamepad = new GamepadService();
            while (!token.IsCancellationRequested)
            {
                var pad = gamepad.GetCurrentReading();
                await UpdateText(CurrentDirection(pad));
            }
        }

        private string CurrentDirection(ControllerDirectionEnum direction)
        {
            switch (direction)
            {
                case ControllerDirectionEnum.Forwards:
                    return "FORWARDS";
                case ControllerDirectionEnum.Reverse:
                    return "REVERSE";
                case ControllerDirectionEnum.Left:
                    return "LEFT";
                case ControllerDirectionEnum.Right:
                    return "RIGHT";
                default:
                    return "NEUTRAL";
            }
        }

        private async Task UpdateText(string message)
        {
            // Update Textbox using the UI thread
            await this.tbDescriptiveText.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { this.tbDescriptiveText.Text = message; });
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.cancelTokenSource.Cancel();
            this.readInputTask.Wait();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.cancelTokenSource = new CancellationTokenSource();

            // Execute the ReadInputLoop() on a background thread
            this.readInputTask = Task.Run(async () => { await this.ReadInputLoop(this.cancelTokenSource.Token); });
        }
    }
}
