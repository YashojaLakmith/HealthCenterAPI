USE Db_HealthCenterAPI;
GO

CREATE PROCEDURE GetCredentialsById
	@Id UNIQUEIDENTIFIER
AS
	SET NOCOUNT ON

	SELECT *
	FROM dbo.[Credentials] AS c
	WHERE c.Id = @UserId;
GO

CREATE PROCEDURE UpdateCredentials
	@Id			UNIQUEIDENTIFIER,
	@PwHash			VARBINARY(256),
	@PwSalt			VARBINARY(256),
	@NewTimeStamp	UNIQUEIDENTIFIER,
	@PrevTimeStamp	UNIQUEIDENTIFIER
AS
	SET NOCOUNT ON

	UPDATE dbo.[Credentials]
	SET
		PasswordHash = @PwHash,
		Salt = @PwSalt,
		CurrentTimeStamp = @NewTimeStamp
	WHERE UserId = @Id AND CurrentTimeStamp = @PrevTimeStamp;

	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR('Concurrent credential modification detected', 16, 1);
	END
GO

CREATE PROCEDURE InsertNewCredentials
	@Id			UNIQUEIDENTIFIER,
	@PwHash		VARBINARY(256),
	@PwSalt		VARBINARY(256),
	@TimeStamp	UNIQUEIDENTIFIER
AS
	SET NOCOUNT ON

	IF EXISTS(SELECT 1 FROM dbo.[Credentials] AS c WHERE c.UserId = @Id)
		RAISERROR('Concurrent modification of credentials detected', 16, 1);
	ELSE
		INSERT INTO dbo.[Credentials]
		VALUES(@PwHash, @PwSalt, @Id, @TimeStamp);

GO