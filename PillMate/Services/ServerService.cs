﻿using System;
using System.Diagnostics;
using System.Windows.Forms; // MessageBox 쓰려면 필요

namespace PillMate.Services
{
    // ServerService.cs
    public class ServerService
    {
        private Process _serverProcess;

        public void StartServer()
        {
            string serverPath = @"C:\Users\YHW\Source\Repos\PillMate.Server";

            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run",
                WorkingDirectory = serverPath,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            try
            {
                _serverProcess = Process.Start(psi);
                _serverProcess.OutputDataReceived += (s, e) => Debug.WriteLine(e.Data);
                _serverProcess.BeginOutputReadLine();
                _serverProcess.ErrorDataReceived += (s, e) => Debug.WriteLine(e.Data);
                _serverProcess.BeginErrorReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 실행 실패: " + ex.Message);
            }
        }

        public void StopServer()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                _serverProcess.Kill(); // 서버 프로세스 종료
                _serverProcess.Dispose();
            }
        }
    }

}
