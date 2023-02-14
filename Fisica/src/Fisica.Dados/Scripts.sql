insert into "Perfil" ("Descricao", "Foto", "Aniversario")
values ('Desenvolvedor', null, current_date)

insert into "Usuario" ("Nome", "Email", "Cpf", "Login", "Senha", "TipoUsuario", "PerfilId", "InstituicaoId")
values('Galileu Frez Veloso', 'galileu.veloso@hotmail.com', '13027434659', 'galileu', '123', 4, 1, null)

insert into "Cidade" ("Nome" , "UF")
values ('Curitiba', 'PR')