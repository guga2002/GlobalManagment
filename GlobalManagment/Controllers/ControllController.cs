using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GlobalManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllController : ControllerBase
    {
        private static DateTime LastBeat = DateTime.MinValue;

        public ControllController(ILogger<ControllController> logger)
        {
        }

        [HttpGet("heartbeat/{fromRobot}")]
        [AllowAnonymous]
        public async Task<DateTime> HeartBeat(bool fromRobot)
        {
            var date = DateTime.UtcNow;
            if (fromRobot)
            {
                LastBeat = date;
            }
            return LastBeat;
        }

        [HttpGet("checkrobot")]
        [AllowAnonymous]
        public async Task<string> CheckRobotHealth()
        {
            string processName = "NatiaGuard.BrainStorm";

            bool isRunning = Process.GetProcessesByName(processName).Any();

            if (!isRunning)
            {
                string exePath = @"C:\Users\MONITORING PC\source\repos\Unite\NatiaGuard.BrainStorm\bin\Release\net8.0\publish\win-x64\NatiaGuard.BrainStorm.exe";
                StartProcess(exePath);
            }

            var date = DateTime.UtcNow;
            var dateRobot = await HeartBeat(false);

            if ((date - dateRobot).TotalMinutes > 2)
            {
                return await Reload();
            }
            return "Robot is healthy";
        }


        [HttpGet("reload")]
        [AllowAnonymous]
        public async Task<string> Reload()
        {
            string exePath = @"C:\Users\MONITORING PC\source\repos\Unite\NatiaGuard.BrainStorm\bin\Release\net8.0\publish\win-x64\NatiaGuard.BrainStorm.exe";
            string processName = "NatiaGuard.BrainStorm";

            StopProcess(processName);
            Thread.Sleep(2000);
            StartProcess(exePath);

            return "Successfully Reloaded";
        }

        private void StopProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                Console.WriteLine($"No running process found with name: {processName}");
                return;
            }

            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                    Console.WriteLine($"Stopped process: {process.ProcessName} (PID: {process.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error stopping process {process.ProcessName}: {ex.Message}");
                }
            }
        }

        private void StartProcess(string exePath)
        {
            try
            {
                Process.Start(exePath);
                Console.WriteLine($"Started process: {exePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting process: {ex.Message}");
            }
        }
    }
}
