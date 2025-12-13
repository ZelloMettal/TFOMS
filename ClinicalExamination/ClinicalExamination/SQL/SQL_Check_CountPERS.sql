USE [Clinical Examination]
GO

CREATE PROCEDURE ChechCountPers
	@result NVARCHAR(100) OUTPUT
AS
BEGIN
	DECLARE
	@kol_m INT,
	@kol_w INT,
	@count_pers INT	
	
	SET @kol_m = (
	SELECT 
		XML.EVENT.query('KOL_M').value('.', 'INT')
	FROM (SELECT CAST(XML AS xml)
		  FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS T(XML)) AS T(XML)
		  CROSS APPLY XML.nodes('ZL_LIST/EVENT') AS XML (EVENT))

	SET @kol_w = (	
	SELECT 
		XML.EVENT.query('KOL_W').value('.', 'INT')
	FROM (SELECT CAST(XML AS xml)
		  FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS T(XML)) AS T(XML)
		  CROSS APPLY XML.nodes('ZL_LIST/EVENT') AS XML (EVENT))
	
	SET @count_pers = (
	SELECT 
		COUNT(XML.PERS.query('N_ZAP').value('.', 'INT'))
	FROM (SELECT CAST(XML AS xml)
		  FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS T(XML)) AS T(XML)
		  CROSS APPLY XML.nodes('ZL_LIST/EVENT/PERS') AS XML (PERS))
	
	IF((@kol_m+@kol_w) = @count_pers)
		SELECT @result = '1 Параметры KOL_M = ' + TRIM(CONVERT(NCHAR, @kol_m)) + ' и KOL_F = ' + TRIM(CONVERT(NCHAR, @kol_w)) + ' соответствуют количеству PERS = ' + TRIM(CONVERT(NCHAR, @count_pers))
	ELSE
		SELECT @result = '-1 Параметры KOL_M = ' + TRIM(CONVERT(NCHAR, @kol_m)) + ' и KOL_F = ' + TRIM(CONVERT(NCHAR, @kol_w)) + ' НЕ соответствуют количеству PERS = ' + TRIM(CONVERT(NCHAR, @count_pers))
END