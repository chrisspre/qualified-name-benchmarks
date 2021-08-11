using Xunit;

namespace IsQualifiedName
{

    public class ValidatorTests
    {
        [Theory]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("a. ", false)]
        [InlineData(".com", false)]
        [InlineData("com.", false)]
        [InlineData(".", false)]
        [InlineData("com", false)]
        [InlineData("a.b.com", true)]
        [InlineData(" a.b.com", true)]
        [InlineData("a.b.com ", true)]
        [InlineData(" a . b . c ", true)] // whitespaces are ok as long as each segments is not jsut whitespace
        [InlineData("a . . c", false)] // second segment just whitespace
        [InlineData("a .. c", false)] // second segment is empty
        public void IsQualifiedName_Test(string name, bool expected)
        {
            var actual = Validator.IsQualifiedName3(name);
            Assert.Equal(expected, actual);
        }
    }

}