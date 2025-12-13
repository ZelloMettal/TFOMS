USE [Clinical Examination]
GO

CREATE PROCEDURE InsertXMLtoDB
	@result NVARCHAR(300) OUTPUT
AS
BEGIN
	DECLARE @event_id int
	
	INSERT INTO ZGLV (VERSION, DATE, FILENAME, YEAR, CODE_MO) 
	SELECT 
		XML.ZGLV.query('VERSION').value('.', 'NCHAR(5)'),
		XML.ZGLV.query('DATE').value('.', 'DATE'),
		XML.ZGLV.query('FILENAME').value('.', 'NCHAR(26)'),
		XML.ZGLV.query('YEAR').value('.', 'smallint'),
		XML.ZGLV.query('CODE_MO').value('.', 'NCHAR(6)')
	FROM (SELECT CAST(XML AS xml)
			FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS T(XML)) AS T(XML)
			CROSS APPLY XML.nodes('ZL_LIST/ZGLV') AS XML (ZGLV)
	
	INSERT INTO EVENT(DISP, KOL_M, KOL_W) 
	SELECT 
		XML.EVENT.query('DISP').value('.', 'NCHAR(3)'),
		XML.EVENT.query('KOL_M').value('.', 'INT'),
		XML.EVENT.query('KOL_W').value('.', 'INT')
	FROM (SELECT CAST(XML AS xml)
			FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS T(XML)) AS T(XML)
			CROSS APPLY XML.nodes('ZL_LIST/EVENT') AS XML (EVENT)
	SET @event_id = SCOPE_IDENTITY()
	
	INSERT INTO PERS(N_ZAP,	ID_PAC,	W, DR, SMO, VPOLIS, SPOLIS, NPOLIS, QUARTER, MONTH, LPU1, DEPTH, SS_DOC, SS_DOC_D,
		PRVS_D, DS_D, PLACE_D, ID_TFOMS, COMMENT, ID_EVENT) 
	SELECT 
		XML.PERS.query('N_ZAP').value('.', 'INT'),
		XML.PERS.query('ID_PAC').value('.', 'NCHAR(36)'),
		XML.PERS.query('W').value('.', 'TINYINT'),
		XML.PERS.query('DR').value('.', 'DATE'),
		XML.PERS.query('SMO').value('.', 'NCHAR(5)'),
		XML.PERS.query('VPOLIS').value('.', 'TINYINT'),
		XML.PERS.query('SPOLIS').value('.', 'NCHAR(10)'),
		XML.PERS.query('NPOLIS').value('.', 'NCHAR(16)'),
		XML.PERS.query('QUARTER').value('.', 'TINYINT'),
		XML.PERS.query('MONTH').value('.', 'TINYINT'),
		XML.PERS.query('LPU1').value('.', 'NCHAR(3)'),
		XML.PERS.query('DEPTH').value('.', 'NCHAR(10)'),
		XML.PERS.query('SS_DOC').value('.', 'NCHAR(11)'),
		XML.PERS.query('SS_DOC_D').value('.', 'NCHAR(11)'),
		XML.PERS.query('PRVS_D').value('.', 'SMALLINT'),
		XML.PERS.query('DS_D').value('.', 'NCHAR(3)'),
		XML.PERS.query('PLACE_D').value('.', 'TINYINT'),
		XML.PERS.query('ID_TFOMS').value('.', 'NCHAR(36)'),
		XML.PERS.query('COMMENT').value('.', 'NCHAR(250)'),
		@event_id
	FROM (SELECT CAST(XML AS xml)
			FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS T(XML)) AS T(XML)
			CROSS APPLY XML.nodes('ZL_LIST/EVENT/PERS') AS XML (PERS)
	
	INSERT INTO CONTACTS(PERS_ID, PHONE_F, PHONE_M, EMAIL, ADDRESS) 
	SELECT 
		XML.CONTACTS.query('PERS_ID').value('.', 'INT'),
		XML.CONTACTS.query('PHONE_F').value('.', 'NCHAR(11)'),
		XML.CONTACTS.query('PHONE_M').value('.', 'NCHAR(11)'),
		XML.CONTACTS.query('EMAIL').value('.', 'NCHAR(50)'),
		XML.CONTACTS.query('ADDRESS').value('.', 'NCHAR(250)')	
	FROM (SELECT CAST(XML AS xml)
			FROM OPENROWSET(BULK 'C:\Project\Work\TFOMS\ClinicalExamination\ClinicalExamination\bin\Debug\INPUT\XML_Test.xml', SINGLE_BLOB) AS T(XML)) AS T(XML)
			CROSS APPLY XML.nodes('ZL_LIST/EVENT/PERS/CONTACTS') AS XML (CONTACTS)
END