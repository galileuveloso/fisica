using Fisica.Api.Extensions;
using Fisica.Api.Features.InstituicaoFeature.Queries;
using Fisica.Api.Helpers;
using Fisica.Classes;
using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
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
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }
        public long? CidadeId { get; set; }
        public string? UF { get; set; }

        public void Validar()
        {
            if (UsuarioId is null || UsuarioId == 0) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.UsuarioId));
            if (String.IsNullOrEmpty(Nome)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Nome));
            if (String.IsNullOrEmpty(Descricao)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Descricao));
            if (String.IsNullOrEmpty(Email)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Email));
            if (String.IsNullOrEmpty(Site)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Site));
            if (String.IsNullOrEmpty(Logradouro)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Logradouro));
            if (String.IsNullOrEmpty(Bairro)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Bairro));
            if (Numero is null || Numero!.Value == 0) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.Numero));
            if (CidadeId is null || CidadeId!.Value == 0) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.CidadeId));
            if (String.IsNullOrEmpty(UF)) throw new ArgumentNullException(MessageHelper.NullFor<InserirInstituicaoCommand>(x => x.UF));
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

            if (!await _repositoryCidade.ExistsAsync(x => x.Id == request.CidadeId!.Value, cancellationToken))
                throw new ObjectNotFoundException("Cidade não encontrada.");

            Instituicao instituicao = request.ToDomain();

            await _repositoryInstituicao.AddAsync(instituicao, cancellationToken);
            await _repositoryInstituicao.SaveChangesAsync(cancellationToken);

            return instituicao.ToResponse();
        }
    }
}
