using Core.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests.Model
{
    
    internal static class UserFacts
    {
        [TestFixture]
        internal sealed class EqualsMessage
        {
            /*
             * EqualsMessage 
             * user.Equals(other) => true|false
             *         (Username : String, CI)
             *  1. With LSOLANO and lsolano should return true
             *  2. With lsolano and l.solano should return false
             *  3. With '  lsolano' and 'lsolano' should return true
             *  4. With 'l solanom' and 'lsolano m' should return false
             */
            [TestCase("  lsolano", "lsolano")]
            [TestCase("LSOLANO", "lsolano")]
            public void ShouldBeEquals(string usernameA, string usernameB)
            {
                // Arrange
                User userA = new User { Username = usernameA };
                User userB = new User { Username = usernameB };

                // Act
                bool actual = userA.Equals(userB);

                // Assert
                Assert.That(actual, Is.True);
            }

            [TestCase("l solanom", "lsolano m")]
            [TestCase("lsolano", "l.solano")]
            public void ShouldBeDifferent(string usernameA, string usernameB)
            {
                User userA = new User { Username = usernameA };
                User userB = new User { Username = usernameB };

                bool actual = userA.Equals(userB);

                Assert.That(actual, Is.False);
            }

            [TestCase("Hola Mundo")]
            [TestCase(1)]
            [TestCase(null)]
            public void ShouldBeDifferentWithOtherTypes(object Other)
            {
                User user = new User { Username = "plebron" };
                
                bool actual = user.Equals(Other);

                Assert.That(actual, Is.False);
            }

            [Test]
            public void ShouldBeEqualsToItSelf()
            {
                User user = new User { Username = "plebron" };

                bool actual = user.Equals(user);

                Assert.That(actual, Is.True);
            }
        }
    }
}
