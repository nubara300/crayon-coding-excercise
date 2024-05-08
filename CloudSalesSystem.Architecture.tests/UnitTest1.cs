using System.Reflection;
using Xunit;

namespace CloudSalesSystem.Architecture.tests
{
    namespace MyApp.Tests
    {
        public class ArchitectureTests
        {
            [Fact]
            public void ProjectReferences_ShouldBeCorrect()
            {
                // Arrange
                var applicationProject = typeof(Application.Accounts.AccountDto).Assembly;
                var infrastructureProject = typeof(Infrastructure.Repositories.UnitOfWork).Assembly;
                var domainProject = typeof(Domain.CLoudSalesConstants).Assembly;

                // Act
                var applicationReferences = GetProjectReferences(applicationProject, infrastructureProject, domainProject);
                var infrastructureReferences = GetProjectReferences(infrastructureProject, applicationProject, domainProject);
                var domainReferences = GetProjectReferences(domainProject, applicationProject, infrastructureProject);

                // Assert
                Assert.Contains(infrastructureProject, applicationReferences);
                Assert.Contains(domainProject, applicationReferences);
                Assert.Contains(applicationProject, infrastructureReferences);
                Assert.Contains(domainProject, infrastructureReferences);
                Assert.Contains(infrastructureProject, domainReferences);
                Assert.Contains(applicationProject, domainReferences);
            }

            private static List<Assembly> GetProjectReferences(Assembly project, params Assembly[] otherProjects)
            {
                var references = project.GetReferencedAssemblies()
                    .Where(a => a.FullName.StartsWith("CLoudSalesSystem"))
                    .ToList();

                foreach (var otherProject in otherProjects)
                {
                    references.Remove(otherProject);
                }

                return references;
            }
        }
    }
}