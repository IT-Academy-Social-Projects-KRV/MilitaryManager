USE Units;

GO

CREATE TRIGGER t_audit_units_insert_delete ON Unit.Units FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_units_update ON Unit.Units FOR UPDATE
AS 
BEGIN
	SET NOCOUNT ON

	DECLARE @Temp TABLE (
		ChangeId INT,
		RowId INT
	)

	DECLARE @tablename VARCHAR(50);

	SELECT @tablename = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.object_id = @@PROCID;

	INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode) 
		OUTPUT inserted.Id, inserted.RowId
			INTO @Temp
		SELECT @tablename, i.Id, CURRENT_TIMESTAMP, 'U'
		FROM inserted as i;

	IF(UPDATE(FirstName))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.FirstName, i.FirstName, 'FirstName'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id
	END;
	IF(UPDATE(LastName))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.LastName, i.LastName, 'LastName'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id
	END;
	IF(UPDATE(ParentId))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.ParentId, i.ParentId, 'UnitParentId'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id		
	END;
	IF(UPDATE(DivisionId))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.DivisionId, i.DivisionId, 'DivisionId'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id
	END;
	IF(UPDATE(RankId))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.RankId, i.RankId, 'RankId'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id
	END;
	IF(UPDATE(PositionId))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.PositionId, i.PositionId, 'PositionId'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id
	END;
END;

GO

CREATE TRIGGER t_audit_divisions_insert_delete ON Unit.Divisions FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_divisions_update ON Unit.Divisions FOR UPDATE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @Temp TABLE (
		ChangeId INT,
		RowId INT
	)

	DECLARE @tablename VARCHAR(50);

	SELECT @tablename = OBJECT_NAME(parent_object_id) 
             FROM sys.objects 
             WHERE sys.objects.object_id = @@PROCID;

	INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode) 
		OUTPUT inserted.Id, inserted.RowId
			INTO @Temp
		SELECT @tablename, i.Id, CURRENT_TIMESTAMP, 'U'
		FROM inserted as i;

	IF(UPDATE([Name]))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.[Name], i.[Name], 'Name'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id
	END;
	IF(UPDATE([Address]))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.[Address], i.[Address], 'Address'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id
	END;
	IF(UPDATE(ParentId))
	BEGIN
		INSERT INTO audit.ChangeValue
			SELECT t.ChangeId, d.ParentId, i.ParentId, 'UnitParentId'
			FROM inserted as i
				JOIN deleted as d ON i.Id = d.Id
				JOIN @Temp as t ON t.RowId = d.Id		
	END;
END;

GO

CREATE TRIGGER t_audit_unitToEquipments_insert_delete ON Unit.UnitToEquipments FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_positions_insert_delete ON Unit.Positions FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_ranks_insert_delete ON Unit.Ranks FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_entities_insert_delete ON Unit.Entities FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_entityToAttributes_insert_delete ON Unit.EntityToAttributes FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_profiles_insert_delete ON Unit.Profiles FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;

GO

CREATE TRIGGER t_audit_attributes_insert_delete ON Unit.Attributes FOR INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @tablename VARCHAR(50);
	
	SELECT @tablename = OBJECT_NAME(parent_object_id)
		FROM sys.objects
		WHERE sys.objects.object_id = @@PROCID;

	IF(EXISTS(SELECT 1 FROM inserted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'I'
			FROM inserted;
	END;
	IF(EXISTS(SELECT 1 FROM deleted))
	BEGIN
		INSERT INTO audit.Change(TableName, RowId, Date, ChangeTypeCode)
			SELECT @tablename, Id, CURRENT_TIMESTAMP, 'D'
			FROM deleted;
	END;
END;