using Fisica.Classes;
using Fisica.Dados.Repositories;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Features.UsuarioFeature.Queries;
using Fisica.Website.Helpers;
using MediatR;
using System.Data;

namespace Fisica.Website.Features.UsuarioFeature.Commands
{
    public class InserirUsuarioCommand : IRequest<UsuarioResponse>
    {
        public long? UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public int? TipoUsuario { get; set; }
        public InstituicaoModel? Instituicao { get; set; }

        public void Validar()
        {
            //TO-DO: Validar
        }
    }

    public class InserirUsuarioHandler : IRequestHandler<InserirUsuarioCommand, UsuarioResponse>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Instituicao> _repositoryInstituicao;

        public InserirUsuarioHandler(IRepository<Usuario> repositoryUsuario, IRepository<Instituicao> repositoryInstituicao)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryInstituicao = repositoryInstituicao;
        }

        public async Task<UsuarioResponse> Handle(InserirUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirUsuarioCommand>());

            request.UsuarioId = 1;
            request.Validar();

            Usuario? admin = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.UsuarioId!.Value, cancellationToken);

            if (admin!.TipoUsuario != (int)TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não possui permissão para inserir usuários.");

            if (await _repositoryUsuario.ExistsAsync(x => x.Cpf == request.Cpf, cancellationToken))
                throw new DuplicateNameException("Já existe um usuário com este cpf.");

            if (await _repositoryUsuario.ExistsAsync(x => x.Email == request.Email, cancellationToken))
                throw new DuplicateNameException("Já existe um usuário com este email.");

            Usuario usuario = request.ToDomain();

            await _repositoryUsuario.CriptografarSenha(usuario);

            await _repositoryUsuario.AddAsync(usuario, cancellationToken);
            await _repositoryUsuario.SaveChangesAsync(cancellationToken);

            return usuario.ToResponse();
        }
    }
}
