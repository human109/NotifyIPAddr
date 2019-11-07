using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Timers;
using Slack.Webhooks;
using Microsoft.Extensions.Configuration;

namespace notifyIpaddr
{
    class NotifyService
    {
        readonly Timer _timer;
        
        private SlackClient slackClient;
        private string CacheIP = String.Empty;

        IConfiguration slackConfig;

        public NotifyService(IConfiguration Configuration)
        {
            slackConfig = Configuration.GetSection("slack");
            
            string slackUrl = slackConfig["Url"];
            slackClient = new SlackClient(slackUrl);
            
            CheckIP();

            _timer = new Timer(10000) { AutoReset = true };
            _timer.Elapsed += _timer_Elapsed;            
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckIP();            
        }

        public void CheckIP()
        {
            var s = new WebClient().DownloadString("http://icanhazip.com");
            if (!s.Equals(CacheIP))
            {
                CacheIP = s;
                NotifyToSlack();
            }            
        }

        private void NotifyToSlack()
        {
            var slackMessage = new SlackMessage
            {
                Channel = slackConfig["Channel"],
                Text = $"{System.Environment.MachineName} - {CacheIP}",
                IconEmoji = Emoji.RobotFace,
                Username = "IP Bot"
            };
            slackClient.Post(slackMessage);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
