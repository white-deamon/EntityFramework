// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.ValueGeneration;
using Microsoft.Framework.DependencyInjection;
using Xunit;

namespace Microsoft.Data.Entity.Tests.ValueGeneration
{
    public class ValueGeneratorCacheTest
    {
        [Fact]
        public void Uses_single_generator_per_property()
        {
            var model = CreateModel();
            var entityType = model.GetEntityType("Led");
            var property1 = entityType.GetProperty("Zeppelin");
            var property2 = entityType.GetProperty("Stairway");
            var cache = TestHelpers.Instance.CreateContextServices(model).GetRequiredService<IValueGeneratorCache>();

            var generator1 = cache.GetOrAdd(property1, entityType, (p, et) => new GuidValueGenerator());
            Assert.NotNull(generator1);
            Assert.Same(generator1, cache.GetOrAdd(property1, entityType, (p, et) => new GuidValueGenerator()));

            var generator2 = cache.GetOrAdd(property2, entityType, (p, et) => new GuidValueGenerator());
            Assert.NotNull(generator2);
            Assert.Same(generator2, cache.GetOrAdd(property2, entityType, (p, et) => new GuidValueGenerator()));
            Assert.NotSame(generator1, generator2);
        }
        
        private static Model CreateModel(bool generateValues = true)
        {
            var model = new Model();

            var entityType = model.AddEntityType("Led");
            entityType.AddProperty("Zeppelin", typeof(Guid));
            entityType.AddProperty("Stairway", typeof(Guid)).RequiresValueGenerator = generateValues;

            return model;
        }
    }
}
