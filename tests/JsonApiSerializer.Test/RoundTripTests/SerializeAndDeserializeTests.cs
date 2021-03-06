﻿using JsonApiSerializer.Test.Models.Articles;
using JsonApiSerializer.Test.TestUtils;
using Newtonsoft.Json;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JsonApiSerializer.Test.RoundTripTests
{
    public class SerializeAndDeserializeTests
    {
        public JsonApiSerializerSettings settings = new JsonApiSerializerSettings()
        {
            Formatting = Formatting.Indented //pretty print makes it easier to debug
        };

        [Fact]
        public void When_serialize_should_deserialize_to_equal_objects()
        {
            var fixture = new Ploeh.AutoFixture.Fixture();
            var product1 = fixture.Create<Article[]>();


            var json = JsonConvert.SerializeObject(product1, settings);
            var product2 = JsonConvert.DeserializeObject<Article[]>(json, settings);

            var equal = TestUtils.JsonObjectEqualityComparer<Article[]>.Instance.Equals(product1, product2);

            Assert.True(equal);

        }
    }
}
