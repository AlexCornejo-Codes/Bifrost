namespace Bifrost.DataShaping.Tests
{
    public sealed class DataShaperTests
    {
        private readonly IDataShaper _shaper = new DataShaper();

        [Fact]
        public void Shape_WhenNoFieldsProvided_ReturnAllProperties()
        {
            var source = new TestModel
            {
                Id = 1,
                Name = "Test",
                Code = "TST",
                Description = "Test Model"
            };
            
            var result = _shaper.Shape(source, null);
            var dict = (IDictionary<string, object?>)result;
            
            Assert.Equal(4, dict.Count);
            Assert.Equal(1, dict["Id"]);
            Assert.Equal("Test", dict["Name"]);
            Assert.Equal("TST", dict["Code"]);
            Assert.Equal("Test Model", dict["Description"]);
        }
        
        [Fact]
        public void Shape_WhenSpecificFieldsProvided_ReturnOnlyRequestedFields()
        {
            var source = new TestModel
            {
                Id = 1,
                Name = "Test",
                Code = "TST",
                Description = "Test Model"
            };

            var result = _shaper.Shape(source, "Id,Name,Code");
            var dict = (IDictionary<string, object?>)result;
            
            Assert.Equal(3, dict.Count);
            Assert.True(dict.ContainsKey("Id"));
            Assert.True(dict.ContainsKey("Name"));
            Assert.True(dict.ContainsKey("Code"));
            Assert.False(dict.ContainsKey("Description"));
        }
        
        [Fact]
        public void Validate_WhenInvalidFieldProvided_ReturnFalse()
        {
            bool isValid = _shaper.Validate<TestModel>("Id,DoesNotExists");
            
            Assert.False(isValid);
        }
    }
}
