// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Relational.Design.ReverseEngineering
{
    public class TableSelection
    {
        public const string Any = "*";
        public static readonly TableSelection InclusiveAll = new TableSelection();
        public static readonly TableSelection ExclusiveAll = new TableSelection() { Exclude = true };

        public virtual string Schema { get;[param: NotNull] set; } = Any;
        public virtual string Table { get;[param: NotNull] set; } = Any;
        public virtual bool Exclude { get; set; }

        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }

            var tableSelection = o as TableSelection;
            if (tableSelection == null)
            {
                return false;
            }

            return Exclude == tableSelection.Exclude
                && Schema == tableSelection.Schema
                && Table == tableSelection.Table;
        }

        public override int GetHashCode()
        {
            return unchecked
                ((Schema.GetHashCode() * 397 ^ Table.GetHashCode()) * 397 ^ Exclude.GetHashCode());
        }

        public virtual bool Matches([NotNull] string schemaName, [NotNull] string tableName)
        {
            Check.NotEmpty(schemaName, nameof(schemaName));
            Check.NotEmpty(tableName, nameof(tableName));

            return (Schema == Any || Schema == schemaName)
                && (Table == Any || Table == tableName);
        }
    }
}
