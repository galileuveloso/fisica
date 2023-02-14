using Fisica.Api.Extensions;
using Fisica.Api.Features.InstituicaoFeature.Queries;
using Fisica.Api.Helpers;
using Fisica.Classes;
using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Models;
using MediatR;
using System.Data;
using System.Data.Entity.Core;

namespace Fisica.Api.Features.InstituicaoFeature.Commands
{
    public class InserirInstituicaoCommand : IRequest<InstituicaoResponse>
    {
        public long? UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public EnderecoModel Endereco { get; set; }

        public void Validar()
        {
            if (UsuarioId is null || UsuarioId == 0) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.UsuarioId));
            if (String.IsNullOrEmpty(Nome)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Nome));
            if (String.IsNullOrEmpty(Descricao)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Descricao));
            if (String.IsNullOrEmpty(Email)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Email));
            if (String.IsNullOrEmpty(Site)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Site));
            if (Endereco is null) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Endereco));
        }
    }

    public class InserirInstituicaoHandler : IRequestHandler<InserirInstituicaoCommand, InstituicaoResponse>
    {
        private readonly IRepository<Instituicao> _repositoryInstituicao;
        private readonly IRepository<Cidade> _repositoryCidade;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public InserirInstituicaoHandler(IRepository<Instituicao> repositoryInstituicao, IRepository<Cidade> repositoryCidade, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryInstituicao = repositoryInstituicao;
            _repositoryCidade = repositoryCidade;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<InstituicaoResponse> Handle(InserirInstituicaoCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>());

            request.Validar();

            Usuario? usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == request.UsuarioId!.Value, cancellationToken);

            if (usuario is null)
                throw new ObjectNotFoundException("Usuário não encontado.");

            if (usuario!.TipoUsuario != (int)TipoUsuario.Adminstrador)
                throw new InvalidOperationException("Usuário não possui permissão para inserir instituições.");

            if (await _repositoryInstituicao.ExistsAsync(x => x.Nome.Equals(request.Nome), cancellationToken))
                throw new DuplicateNameException("Já existe uma instituição com este nome.");

            if (await _repositoryInstituicao.ExistsAsync(x => x.Email.Equals(request.Email), cancellationToken))
                throw new DuplicateNameException("Já existe uma instituição com este e-mail.");

            if (!await _repositoryCidade.ExistsAsync(x => x.Id == request.Endereco!.CidadeId, cancellationToken))
                throw new ObjectNotFoundException("Cidade não encontrada.");

            Instituicao instituicao = request.ToDomain();

            await _repositoryInstituicao.AddAsync(instituicao, cancellationToken);
            await _repositoryInstituicao.SaveChangesAsync(cancellationToken);

            return instituicao.ToResponse();
        }
    }
}
