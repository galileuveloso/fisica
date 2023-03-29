using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;
using System.Data.Entity.Core;

namespace Fisica.Website.Features.AulaFeature.Commands
{
    public class InserirAulaCommand : IRequest<AulaModel>
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public long? AreaFisicaId { get; set; }
        public IEnumerable<SessaoAulaModel> Sessoes { get; set; }
        public void Validar()
        {

        }
    }

    public class InserirAulaHandler : IRequestHandler<InserirAulaCommand, AulaModel>
    {
        private readonly IRepository<Aula> _repositoryAula;
        private readonly IRepository<AreaFisica> _repositoryAreaFisica;
        private readonly IRepository<SessaoAula> _repositorySessaoAula;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public InserirAulaHandler(IRepository<Aula> repositoryAula, IRepository<AreaFisica> repositoryAreaFisica, IRepository<SessaoAula> repositorySessaoAula, IRepository<Usuario> repositoryUsuario)
        {
            _repositoryAula = repositoryAula;
            _repositoryAreaFisica = repositoryAreaFisica;
            _repositorySessaoAula = repositorySessaoAula;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<AulaModel> Handle(InserirAulaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirAulaCommand>());

            request.Validar();

            Usuario usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario!.Value, cancellationToken);

            if (usuario.TipoUsuarioEnum != TipoUsuario.Professor && usuario.TipoUsuarioEnum != TipoUsuario.ProfessorAdministrador)
                throw new InvalidOperationException("Usuário não pode cadastrar aulas.");

            AreaFisica areaFisica = await _repositoryAreaFisica.GetSingleAsync(x => x.Id == request.AreaFisicaId!.Value, cancellationToken);

            if (areaFisica is null)
                throw new ObjectNotFoundException("Área da Física não encontrada.");

            Aula aula = request.ToDomain();
            aula.Professor = usuario;
            aula.AreaFisica = areaFisica;

            await _repositoryAula.AddAsync(aula, cancellationToken);
            await _repositoryUsuario.SaveChangesAsync(cancellationToken);

            IList<SessaoAula> sessoes = new List<SessaoAula>();

            foreach (SessaoAulaModel sessao in request.Sessoes)
                sessoes.Add(sessao.ToDomain(aula.Id));

            await _repositorySessaoAula.AddCollectionAsync(sessoes, cancellationToken);
            await _repositorySessaoAula.SaveChangesAsync(cancellationToken);

            //TO-DO: Implementar salvar os arquivos no ged

            return aula.ToResponse();
        }
    }
}
