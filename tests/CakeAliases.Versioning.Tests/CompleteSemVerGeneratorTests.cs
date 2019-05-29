using CakeAliases.Versioning;
using System;
using Xunit;

namespace CakeAliases.BranchesSemVer.Tests
{
    public class CompleteSemVerGeneratorTests
    {
        [Fact]
        public void IfVersionLessThenMajor1_thenAlphaSuffixIsAdded()
        {
            var version = NugetVersioning.GetVersion(null, "0.1.0");

            Assert.Equal("0.1.0-alpha", version);
        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_ThenNoSuffixIsAdded()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0");

            Assert.Equal("1.0.0", version);

        }


        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsRelease_ThenReleaseSuffixMustAppear()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0","release");

            Assert.Equal("1.0.0-rc", version);

        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsDev_ThenReleaseSuffixMustAppear()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0", "dev");

            Assert.Equal("1.0.0-beta", version);

        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsNotKnown_ThenReleaseSuffixMustAppear()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0", "feature");

            Assert.Equal("1.0.0-alpha", version);

        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsNotKnown_AndBuildNumberProvided_ThenReleaseSuffixMustAppear_WithBuildNumber()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0", "feature","1");

            Assert.Equal("1.0.0-alpha1", version);

        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsDev_AndBuildNumberProvided_ThenReleaseSuffixMustAppear_WithBuildNumber()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0", "dev", "1");
            Assert.Equal("1.0.0-beta1", version);
        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsMaster_AndBuildNumberProvided_ThenReleaseSuffixMustNotAppear()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0", "master", "1");

            Assert.Equal("1.0.0", version);

        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsRelease_AndBuildNumberProvided_ThenReleaseSuffixMustAppear_WithBuildNumber()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0", "release", "1");

            Assert.Equal("1.0.0-rc1", version);

        }

        [Fact]
        public void IfVersionEqualOfHigherThen1_AndBranchIsMain_AndBuildNumberProvided_ThenReleaseSuffixMustNotAppear()
        {
            var version = NugetVersioning.GetVersion(null, "1.0.0", "Main", "1");

            Assert.Equal("1.0.0", version);

        }



    }
}
