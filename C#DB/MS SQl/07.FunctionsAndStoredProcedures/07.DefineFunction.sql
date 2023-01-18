CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(30))
RETURNS BIT
AS
BEGIN 
	DECLARE @isWordCompromised INT = 0
	DECLARE @i INT = 1

	WHILE @i <= LEN(@word)
	BEGIN 
		DECLARE @wordLetter CHAR(1) = SUBSTRING(@word, @i, 1)

		DECLARE @j INT = 1

		WHILE @j <= LEN(@setOfLetters)
		BEGIN
			DECLARE @setLetter CHAR(1) = SUBSTRING(@setOfLetters, @j, 1)

			IF @wordLetter = @setLetter
			BEGIN
				SET @isWordCompromised = 1;
				BREAK
			END
			SET @j += 1
			SET @isWordCompromised = 0;
		END

		IF @isWordCompromised = 0
			RETURN 0
		SET @i += 1 
	END
	RETURN 1
END

GO 

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')