USE [Clinical Examination]
GO

CREATE PROCEDURE CheckValidation
	@result NVARCHAR(300) OUTPUT
AS
	BEGIN
	DECLARE 
	@xml xml,
	@schema XML(Validator)
	
	SELECT @xml = XML_FILE
	FROM (SELECT CAST(XML_FILE AS xml)
			FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS X(XML_FILE)) AS X(XML_FILE)
	
	BEGIN TRY
		SELECT @schema = @xml
		SELECT @result = '1 XML-файл валидный'
	END TRY
	BEGIN CATCH
		SELECT @result = '-1 XML-файл НЕ валидный' + CHAR(10) + ERROR_MESSAGE()
	END CATCH
END