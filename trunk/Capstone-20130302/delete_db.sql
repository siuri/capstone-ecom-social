SELECT * 
  INTO [TempMigrationHistory] 
  FROM [__MigrationHistory]

  DROP TABLE [__MigrationHistory]

  EXEC sp_rename 'TempMigrationHistory', '__MigrationHistory'