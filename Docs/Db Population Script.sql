USE master
GO

SET IDENTITY_INSERT cm.Role ON
INSERT INTO cm.Role (id_Role, nm_Role)
VALUES
		(1, 'Analista de negócio'),
		(2, 'Analista de sistemas'),
		(3, 'Gerente de projetos'),
		(4, 'Diretor de TI'),
		(5, 'Recursos Humanos')		

SET IDENTITY_INSERT cm.Role OFF
GO	