using System.Collections.Generic;
using System.Text;

namespace Fox.Core.Utils
{
    public class TaskLogger
    {
        private readonly HashSet<string> warnings = new HashSet<string>();
        private readonly HashSet<string> errors = new HashSet<string>();
        private readonly string taskName;

        public TaskLogger(string taskName)
        {
            this.taskName = taskName;
        }

        public void AddWarning(string warning)
        {
            _ = this.warnings.Add(warning);
        }

        public void AddWarningMissingAsset(string path)
        {
            _ = this.warnings.Add($"Unable to find asset at path {path}.");
        }

        public void AddWarningNullProperty(string propertyName)
        {
            _ = this.warnings.Add($"Property '{propertyName}' is null.");
        }

        public void AddError(string error)
        {
            _ = this.errors.Add(error);
        }

        public void LogToUnityConsole()
        {
            this.LogErrors();
            this.LogWarnings();
        }

        private void LogWarnings()
        {
            if (warnings.Count == 0)
            {
                return;
            }

            var builder = new StringBuilder();
            _ = builder.AppendLine($"{taskName} Warnings:");
            foreach (string warning in warnings)
            {
                _ = builder.AppendLine(warning);
            }

            UnityEngine.Debug.LogWarning(builder.ToString());
        }

        private void LogErrors()
        {
            if (errors.Count == 0)
            {
                return;
            }

            var builder = new StringBuilder();
            _ = builder.AppendLine($"{taskName} Errors:");
            foreach (string error in errors)
            {
                _ = builder.AppendLine(error);
            }

            UnityEngine.Debug.LogError(builder.ToString());
        }
    }
}
