﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Migrations.Utilities;
using Microsoft.Framework.Logging;

namespace Microsoft.Data.Entity.Migrations.Infrastructure
{
    internal static class MigratorLoggerExtensions
    {
        public static void CreatingHistoryTable([NotNull] this ILogger logger)
        {
            Check.NotNull(logger, "logger");

            logger.WriteInformation(
                MigratorLoggerEventIds.CreatingHistoryTable,
                Strings.FormatMigratorLoggerCreatingHistoryTable);
        }

        public static void DroppingHistoryTable([NotNull] this ILogger logger)
        {
            Check.NotNull(logger, "logger");

            logger.WriteInformation(
                MigratorLoggerEventIds.DroppingHistoryTable,
                Strings.FormatMigratorLoggerDroppingHistoryTable);
        }

        public static void ApplyingMigration([NotNull] this ILogger logger, [NotNull] string migrationId)
        {
            Check.NotNull(logger, "logger");
            Check.NotEmpty(migrationId, "migrationId");

            logger.WriteInformation(
                MigratorLoggerEventIds.ApplyingMigration, migrationId,
                Strings.FormatMigratorLoggerApplyingMigration);
        }

        public static void RevertingMigration([NotNull] this ILogger logger, [NotNull] string migrationId)
        {
            Check.NotNull(logger, "logger");
            Check.NotEmpty(migrationId, "migrationId");

            logger.WriteInformation(
                MigratorLoggerEventIds.RevertingMigration, migrationId,
                Strings.FormatMigratorLoggerRevertingMigration);
        }

        public static void UpToDate([NotNull] this ILogger logger)
        {
            Check.NotNull(logger, "logger");

            logger.WriteInformation(
                MigratorLoggerEventIds.UpToDate,
                Strings.FormatMigratorLoggerUpToDate);
        }
    }
}