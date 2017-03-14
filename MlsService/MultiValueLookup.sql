ALTER FUNCTION [dbo].[MultiValueLookup]

	(@MetaDataType nvarchar(128),@MultiShortValues nvarchar(1000))
--Takes a string of comma seperated shortvalues and coverts them to comma seperated long values
RETURNS  nvarchar(1000)

/*-------------TEST CODE----------------



SELECT dbo.MultiValueLookup('Association','POL,BBQ,TNS')
	


*/



AS


BEGIN
	DECLARE @MultiLongValues nvarchar(1000) = null
			,@Index int 
			,@ShortTemp nvarchar(128) = null
			,@LongTemp nvarchar(128) = null
			,@Commas int = 1
	
	WHILE (@Commas > 0 )
	BEGIN
		
		SET @Index = CHARINDEX(',', @MultiShortValues,0)
		--case: only one short value, i.e. no commas
		IF (@Index = 0)
			BEGIN
			--store the sole short value
			SET @ShortTemp = SUBSTRING(@MultiShortValues,1, LEN(@MultiShortValues))
			--indicate this is the final short value to be processed
			SET @Commas = 0
		    END
	    --case: more than one short value
		ELSE
			BEGIN
			--store the first short value, trim any white space while you're at it
			SET @ShortTemp = RTRIM(LTRIM(SUBSTRING(@MultiShortValues, 0, @Index)))
			--indicate this is not the final short value to be processed
			SET @Commas = 1
			END

		SELECT @LongTemp = MDL.LongValue
		FROM MetaDataLookup as MDL
		WHERE MDL.MetaDataValue = @ShortTemp
		AND 
		MDL.MetaDataType = @MetaDataType

		IF (@Commas > 0) 
		BEGIN
	    SET @MultiLongValues = CONCAT(@MultiLongValues, @LongTemp,', ')
		END
		ELSE
		BEGIN
		SET @MultiLongValues = CONCAT(@MultiLongValues, @LongTemp)
		END
		SET @MultiShortValues = STUFF(@MultiShortValues,   1, @Index,   '')
	END
	


	RETURN @MultiLongValues

END
