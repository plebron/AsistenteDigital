using Core.Boundaries;
using Core.Model;
using Core.UseCases;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests.Model
{
    internal static class LoadLandingPageDataFacts
    {
        // Dependencies
        // ITaskReposiroty, ISystemInfoRepository

        [TestFixture]
        internal sealed class ConstructorMessage
        {
            [Test]
            public void WithNullTaskRepoShouldThrowException()
            {
                ITaskRepository taskRepo = Substitute.For<ITaskRepository>();
                ISystemInfoRepository sysInfoRepo = null;

                Assert.That(() => new LoadLandingPageData(taskRepo, sysInfoRepo), 
                    Throws.ArgumentNullException.With.Message.Contains("sysInfoRepo"));
            }

            [Test]
            public void WithAllDependenciesNotNUllShouldFail()
            {
                ITaskRepository taskRepo = Substitute.For<ITaskRepository>();
                ISystemInfoRepository sysInfoRepo = Substitute.For<ISystemInfoRepository>();

                LoadLandingPageData userCase = new LoadLandingPageData(taskRepo, sysInfoRepo);

                Assert.That(()=> new LoadLandingPageData(taskRepo, sysInfoRepo), Throws.Nothing);
            }

            [Test]
            public void WithOneUserAndNoTask()
            {
                ITaskRepository taskRepo = Substitute.For<ITaskRepository>();
                taskRepo.GetTotalCount().Returns(0);
                taskRepo.GetTaskFor(Arg.Any<User>()).Returns(new HashSet<Core.Model.Task>());

                ISystemInfoRepository sysInfoRepo = Substitute.For<ISystemInfoRepository>();
                sysInfoRepo.GetActiveUsers().Returns(1);

                LoadLandingPageData userCase = new LoadLandingPageData(taskRepo, sysInfoRepo);
                User theUser = new User() { Username= "plebron"};

                LandingPageData data = userCase.GetData(theUser);

                Assert.That(data.ActiveUsers, Is.EqualTo(1));
                Assert.That(data.TotalTasks, Is.EqualTo(0));
                Assert.That(data.UserTasks, Has.Count.EqualTo(0));
            }

            // Si al metodo se le envia un usuario nulo, deberia de lanzar una excepcion
            // Si el usuario no esta autenticado, debera de lanzar una excepcion o mostrar todo vacio.
        }
    }
}
