using DDL.Database_Layer.Entities;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.BLL.Models.ViewModels;
using Jandag.BLL.Services;
using Jandag.Persistance.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;

namespace GlobalManagment.Controllers
{
    public class UniteController : Controller
    {
        private readonly ISatteliteFrequencyService ser;
        private readonly IService chanells;
        private readonly IService seq;
        private readonly ITemperatureService temperature;
        private readonly RegionInfo regioninfo;
        private readonly HttpClient _client;

        public UniteController(ISatteliteFrequencyService ser, IService chanells, IService seq, ITemperatureService temperature, HttpClient client)
        {
            this.ser = ser;
            this.chanells = chanells;
            this.seq = seq;
            this.temperature = temperature;
            regioninfo=new RegionInfo();
            _client = client;
        }


        private async Task CallRobotHealth()
        {
            try
            {
                string baseUrl = "http://192.168.0.79:3395/api/controll/checkrobot";
                var res = await _client.GetAsync(baseUrl);


                if (!res.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Shecdoma natias gadatvirtvisas");
                }
                await Console.Out.WriteLineAsync(await res.Content.ReadAsStringAsync());
            }
            catch (Exception exp)
            {
                await SentMessagToGuga(BuildHtmlMessage(exp.Message, exp.StackTrace));
            }
        }

        public async Task<IActionResult> getRegionInfo()
        {
            int port = 183;
            UdpClient client = new UdpClient(port);

            try
            {
                while (true)
                { 
                    IPEndPoint clientendpoi=new IPEndPoint(IPAddress.Any, 0);
                    var recievedinfo = client.Receive(ref clientendpoi);

                    string message = Encoding.UTF8.GetString(recievedinfo);
                    return Ok(message);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }

        }
        public async Task<IActionResult> Index()
        {
            Stopwatch watch = new Stopwatch();
            aqa:
            UniteModel mod = new UniteModel();
            try
            {
                watch.Start();
                // var region =await  regioninfo.Getinfo();
                var res = await ser.GetMonitoringFrequencies();
                var ports = await chanells.GetPortsWhereAlarmsIsOn();
                try
                {
                    var portsregion = await ser.GetAllarmsFromRegion();
                    ports.AddRange(portsregion);//add info from region
                }
                catch (Exception exp)
                {
                    await Console.Out.WriteLineAsync(exp.Message);
                    await SentMessagToGuga(BuildHtmlMessage(exp.Message, exp.StackTrace));
                    ports.AddRange(new List<int> { 370, 371, 372, 373 });//turn off all  relay if errror ocured
                }
                foreach (var item in res)
                {
                    foreach (var it in item.details)
                    {
                        if (ports.Contains(it.PortIn250))
                        {
                            it.HaveError = true;
                        }
                        else
                        {
                            it.HaveError = false;
                        }

                    }
                }
      
                mod.satelliteview = res;
                UniteChanellNamesAndAlarms data = new UniteChanellNamesAndAlarms()
                {
                    namees = await seq.GetChanellNames(),
                    ports = await seq.GetPortsWhereAlarmsIsOn(),
                };
                //mod.RegionResponse=region;
                mod.chyanellnameandalarm = data;
                var result = await temperature.GetCUrrentTemperature();
                mod.temperature = result.Item1;
                mod.Humidity = result.Item2;
                watch.Stop();
                await Console.Out.WriteLineAsync(Guid.NewGuid().ToString());
                await Console.Out.WriteLineAsync(watch.ElapsedMilliseconds.ToString());
                await CallRobotHealth();
                return View(mod);
            }
            catch (Exception exp)
            {
                await Console.Out.WriteLineAsync(exp.Message);
                await SentMessagToGuga(BuildHtmlMessage(exp.Message,exp.StackTrace));
                await Task.Delay(TimeSpan.FromSeconds(2));
                goto aqa;
            }
           
        }

        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPort = 587; 
        private const string SenderEmail = "globaltvmanagment@gmail.com";
        private const string SenderPassword = "reoiuyqgeipepngo";

        private async Task SentMessagToGuga(string Message)
        {
            try
            {
                using var smtpClient = new SmtpClient(SmtpServer)
                {
                    Port = SmtpPort,
                    Credentials = new NetworkCredential(SenderEmail, SenderPassword),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(SenderEmail),
                    Subject = $"საიტი გაითშა გუგა: {DateTime.Now}",
                    Body = Message,
                    IsBodyHtml = true 
                };

                mailMessage.To.Add("aapkhazava22@gmail.com");

                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Message sent successfully to Guga.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }

        private string BuildHtmlMessage(string message, string stackTrace)
        {
            return $@"
    <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    line-height: 1.6;
                    background-color: #f9f9f9;
                    color: #333;
                    padding: 20px;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    background: #fff;
                    border: 1px solid #ddd;
                    border-radius: 8px;
                    padding: 20px;
                    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                }}
                h2 {{
                    color: #e74c3c;
                    border-bottom: 2px solid #e74c3c;
                    padding-bottom: 5px;
                }}
                .problem {{
                    margin: 20px 0;
                    padding: 10px;
                    background-color: #fbe9e7;
                    border-left: 4px solid #e74c3c;
                    color: #e74c3c;
                }}
                .stacktrace {{
                    background-color: #f4f4f4;
                    border: 1px solid #ddd;
                    padding: 10px;
                    border-radius: 5px;
                    white-space: pre-wrap;
                    font-family: Consolas, monospace;
                }}
                .footer {{
                    margin-top: 20px;
                    font-size: 0.9em;
                    color: #666;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h2>🚨 პრობლემა გვაქვს</h2>
                <p>გუგა,</p>
                <p>საიტი გაითიშა, ნათია ვარ:</p>
                <div class='problem'>
                    <strong>ეს შეცდომა გვაქვს:</strong> {message}
                </div>
                <p><strong>დეტალურად:</strong></p>
                <div class='stacktrace'>{stackTrace}</div>
                <p><strong>დამატებით ინფორმაცია:</strong></p>
                <div class='stacktrace'>გუგა მეც ვცდილობ გამოსწორებას, სერვისების სიცოცხლე გადავამოწმე, გვერდს ვარეფრეშებ, როცა მოიცლი გადაამოწმე</div>
                <p class='footer'>
                    ეს  ესემესი არის გადაუდებელი სიტუაციებისთვის გათვლილი, გთხოვ გადაამოწმო<br>
                    <em>ნათია ჯანდაგიშვილი</em>
                </p>
            </div>
        </body>
    </html>";
        }

    }
}
