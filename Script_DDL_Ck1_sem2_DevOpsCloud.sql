/*
    -- Para apagar as tabelas - a estrutura e os dados
DROP TABLE TB_CONTA;
DROP TABLE TB_CLIENTE;

    -- Para apagar os dados das tabelas
DELETE FROM TB_CLIENTE
DELETE FROM TB_CONTA

    -- Para apagar uma linha específica da tabela
DELETE FROM TB_CLIENTE WHERE ID_CLIENTE = [coloque o id aqui];
DELETE FROM TB_CONTA WHERE ID_CONTA = [coloque o id aqui];
DELETE FROM TB_CONTA WHERE ID_CLIENTE = [coloque o id do cliente aqui];
*/

    -- Criação da tabela de dados dos clientes
CREATE TABLE tb_cliente (
    id_cliente   NUMBER
        GENERATED ALWAYS AS IDENTITY ( START WITH 1 INCREMENT BY 1 ),
    nm_cliente   VARCHAR2(40) NOT NULL,
    nr_cpf       CHAR(11) NOT NULL,
    ds_email     VARCHAR2(30) NOT NULL,
    nr_telefone  CHAR(13) -- FORMATO TELEFONE'55xx9xxxxxxxx'
);

--ALTER TABLE tb_cliente ADD CONSTRAINT pk_cliente PRIMARY KEY ( id_cliente );


    -- Criação da tabela de dados das contas
CREATE TABLE tb_conta (
    id_conta    NUMBER
        GENERATED ALWAYS AS IDENTITY ( START WITH 1 INCREMENT BY 1 ),
    id_cliente  NUMBER NOT NULL,
    /*nm_cliente  varchar(40) not null,*/
    nr_conta    NUMBER NOT NULL,
    ds_tipo     VARCHAR2(10) NOT NULL, -- 'POUPANÃ‡A OU CORRENTE';
    nr_saldo    NUMBER(8, 2) NOT NULL,
    st_conta    char(1) NOT NULL
);

ALTER TABLE tb_conta ADD CONSTRAINT tb_conta_pk PRIMARY KEY ( id_conta );

ALTER TABLE tb_conta
    ADD CONSTRAINT fk_conta_cliente FOREIGN KEY ( id_cliente )
        REFERENCES tb_cliente ( id_cliente );
        
-- Consultas

SELECT * FROM tb_cliente;
SELECT * FROM tb_conta;

commit;