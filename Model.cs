using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brayns.BCT
{
    public class ProfileData
    {
        public string PowerShellPath { get; set; } = "";
        public string InstanceName { get; set; } = "";
        public string DatabaseServer { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string DatabaseLogin { get; set; } = "";
        public string DatabasePassword { get; set; } = "";
        public bool DatabaseIntegratedSecurity { get; set; } = false;
        public List<string> DevelopmentPaths { get; set; } = new(); 
    }

    public class Settings
    {
        public bool WindowMaximized { get; set; } = false;
        public int? WindowTop { get; set; } = null;
        public int? WindowLeft { get; set; } = null;
        public int? WindowWidth { get; set; } = null;
        public int? WindowHeight { get; set; } = null;
        public int? WindowSplitSize { get; set; } = null;
        public string? LastProfile { get; set; } = null;
    }
}
