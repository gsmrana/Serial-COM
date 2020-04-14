using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Serial_COM
{
    public class AppUpdater
    {
        readonly string _username;
        readonly string _projectname;
        string _installerFilename;

        public delegate void UpdateStatusHandler(string message);
        public event UpdateStatusHandler OnStatusUpdate;

        public delegate void DownloadCompletedHandler();
        public event DownloadCompletedHandler OnDownlodCompleted;

        public AppUpdater(string username, string projectname)
        {
            _username = username;
            _projectname = projectname;
        }

        public void RunUpdateProcess(Version currentAppVersion)
        {
            UpdateStatus("Checking for update...");
            var github = new Octokit.GitHubClient(new Octokit.ProductHeaderValue(_projectname));
            var release = github.Repository.Release.GetAll(_username, _projectname).Result.FirstOrDefault();

            var verstr = release.TagName;
            if (verstr.StartsWith("v")) verstr = verstr.Remove(0, 1);
            if (verstr.Count(c => c == '.') < 3) verstr += ".0";
            var latestversion = new Version(verstr);
            if (latestversion > currentAppVersion)
            {
                var message = string.Format("A new version {0} is available!\rDo you want to download and install?", release.TagName);
                var result = MessageBox.Show(message, "Update Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }
            else
            {
                MessageBox.Show("You are already using the latest version!", "Update Check",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _installerFilename = Path.Combine(Path.GetTempPath(), release.Assets.FirstOrDefault().Name);
            UpdateStatus(string.Format("Downloading... 0%, Total {0} bytes to {1}",
                release.Assets.FirstOrDefault().Size, Path.GetFileName(_installerFilename)));
            using (var webclient = new WebClient())
            {
                webclient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                webclient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                webclient.DownloadFileAsync(new Uri(release.Assets.FirstOrDefault().BrowserDownloadUrl), _installerFilename);
            }
        }

        private void UpdateStatus(string message)
        {
            OnStatusUpdate?.Invoke(message);
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                UpdateStatus(string.Format("Downloading... {0}%, {1} of {2} bytes",
                    e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive));
            }
            catch (Exception ex)
            {
                UpdateStatus("DownloadProgress Exception: " + ex.Message);
            }
        }

        private void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null) throw e.Error;
                UpdateStatus("Installing: " + Path.GetFileName(_installerFilename));
                Process.Start(_installerFilename);
                OnDownlodCompleted?.Invoke();
            }
            catch (Exception ex)
            {
                UpdateStatus("Download Exception: " + ex.Message);
            }
        }

    }
}
