using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CakeAliases.Versioning
{
    public static class NugetVersioning
    {
        [CakeMethodAlias]
        public static string GetVersion(this ICakeContext context, string semverVersion, string branchName = "master", string buildNumber = null)
        {
            string semVerRegEx = "((?:0|[1-9]\\d*)\\.(?:0|[1-9]\\d*)\\.(?:0|[1-9]\\d*))";
            string alphaSemVerPattern = "((?:0\\d*)\\.(?:0|[1-9]\\d*)\\.(?:0|[1-9]\\d*))";

            if (!Regex.IsMatch(semverVersion, semVerRegEx))
                throw new ArgumentException("must have a semver version number");

            if (string.IsNullOrEmpty(buildNumber))
                buildNumber = string.Empty;

           
            List<string> mainBranches = new List<string>() { "Main", "master" };
            List<string> developBranches = new List<string>() { "develop", "dev" };
            List<string> release = new List<string>() { "release","staging","qa" };

            var match = Regex.Match(semverVersion, alphaSemVerPattern);
            if (match.Success)
            {
                return string.Concat(semverVersion, $"-alpha{buildNumber}");
            }

            if (mainBranches.Contains(branchName))
            {
                return semverVersion;
            }

            if (developBranches.Contains(branchName))
            {
                return string.Concat(semverVersion,$"-beta{buildNumber}");
            }

            if (release.Contains(branchName))
            {
                return string.Concat(semverVersion, $"-rc{buildNumber}");
            }

            return string.Concat(semverVersion, $"-alpha{buildNumber}");

        }
    }
}
