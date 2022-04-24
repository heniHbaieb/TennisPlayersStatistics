using Application.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace Test.Helpers
{
    public class EnumHelperTest
    {
        [Theory]
        [MemberData(nameof(EnumList))]
        public void Should_GetTheRight_Description(TestEnum enumToTest, string description)
        {
            Assert.Equal(description, enumToTest.GetDescription());
        }

        public static IEnumerable<object[]> EnumList = new List<object[]>()
        {
            new object[]
            {
                TestEnum.T1,
                "Test Num 1"
            },
            new object[]
            {
                TestEnum.T3,
                "Test Num 3"
            },
        };

        public enum TestEnum
        {
            [Description("Test Num 1")]
            T1,
            [Description("Test Num 2")]
            T2,
            [Description("Test Num 3")]
            T3
        }
    }
}
