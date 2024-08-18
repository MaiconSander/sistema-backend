CREATE DATABASE programacao_do_zero;

USE programacao_do_zero;

-- tabela usuario
CREATE TABLE usuario (
id INT NOT NULL AUTO_INCREMENT,
   nome VARCHAR(50) NOT NULL,
   sobrenome VARCHAR(150) NOT NULL,
   telefone VARCHAR(15) NOT NULL,
   email VARCHAR(50) NOT NULL,
   genero VARCHAR(20) NOT NULL,
   senha VARCHAR(50) NOT NULL,
   PRIMARY KEY (id)
);

-- tabela endereço
CREATE TABLE endereco (
id INT NOT NULL AUTO_INCREMENT,
 rua VARCHAR(250) NOT NULL,
 numero VARCHAR(30) NOT NULL,
 bairro VARCHAR(150) NOT NULL,
 cidade VARCHAR(250) NOT NULL,
 complemneto VARCHAR(150) NOT NULL,
 cep VARCHAR(9) NOT NULL,
 estado VARCHAR(2) NOT NULL,
 PRIMARY KEY (id)
);

-- Comando de alterar tabela
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- Adicionar chave estrangeira
ALTER TABLE endereco
ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--Inserir usuarios
INSERT INTO usuario(nome,sobrenome,telefone,email,genero,senha) 
VALUES ('Maicon', 'martins', '(38) 9986-40554', 'maiconvinsmoke@gmail.com', 'masculino', '123')

INSERT INTO usuario
(nome,sobrenome,email,telefone,genero,senha)
VALUES
('jude', 'sander', 'jude@1gmail.com', '11 92541-9863','masculino', 'willian1'); 

-- Selecionar  todos os usuarios
SELECT * FROM usuario;

-- Selecionar um usuario especifico
SELECT * FROM usuario WHERE email = 'maiconvinsmoke@gmail.com';

-- Alterar Usuario
UPDATE usuario SET email = 'maiconlopes@gmail.com' WHERE id = 3;

-- Excluir Usuario
DELETE FROM usuario WHERE id = 2;